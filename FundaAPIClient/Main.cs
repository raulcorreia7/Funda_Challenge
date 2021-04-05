using System;
using System.Buffers;
using DocoptNet;
using Serilog;
using Serilog.Events;

namespace FundaAPIClient
{
    class Program
    {

        const string USAGE =
        @"
        Usage: 
            fundaclient (--apikey=<key>) (--query=<q>) [--quiet | --debug | --verbose] 
            fundaclient --apikey=mykey --query=all
            fundaclient --apikey=mykey --query=tuin
            fundaclient --apikey=mykey --query=all --quiet
            fundaclient --apikey=mykey --query=tuin --verbose

        Options
            -h --help Show help.
            -s --sorted Sorted output.
            --apikey=<key> API key for funda api endpoint.
            --query=<q> Type of query : all or tuin.
             --quiet Minimal printing of logs.
            --verbose Verbose printing of logs.
            --debug Debug printing of logs.
        ";
        static void Main(string[] args)
        {


            var docopt = new Docopt();
            var arguments = docopt.Apply(USAGE, args, exit: true);
            foreach (var argument in arguments)
            {
                switch (argument.Key)
                {
                    case "--verbose":
                        if (argument.Value.IsFalse == false)
                        {
                            Logger.SetupDefaultLogger(LogEventLevel.Verbose);
                        }
                        break;
                    case "--debug":
                        if (argument.Value.IsFalse == false)
                        {
                            Logger.SetupDefaultLogger(LogEventLevel.Debug);
                        }
                        break;
                    case "--quiet":
                        if (argument.Value.IsFalse == false)
                        {
                            Logger.SetupDefaultLogger(LogEventLevel.Error);
                        }
                        break;
                    default:
                        break;
                }
            }
            Configuration.GetConfiguration().APIKey = arguments["--apikey"].ToString();

            Log.Information($"Application :: Starting...");
            FundaClientBuilder builder = new FundaClientBuilder();

            IFundaAPIClient fundaClient = builder.WithRestAPICrawler()
                    .WithFundaJsonDataProcessor()
                    .Build();

            FundaResults result = null;
            string method = null;
            switch (arguments["--query"].ToString())
            {
                case "all":
                    method = "Get Top 10 Makelaars";
                    result = fundaClient.GetTop10Makelaars();
                    break;
                case "tuin":
                    method = "Get Top 10 Makelaars with Tuin";
                    result = fundaClient.GetTop10MakelaarsWithTuin();
                    break;
                default:
                    Log.Error("Application :: Unknown query, exiting application.");
                    Environment.Exit(1);
                    break;
            }
            if (result == null ||
                result.IsDataComplete == false)
            {
                Log.Error($"Application :: Failed to execute {method}.");
                Environment.Exit(1);
            }

            if (result != null &&
                result.IsDataComplete)
            {
                string table = result.GetTableString();
                Log.Debug($"Application :: Result of {method} is \n {table}\n");
                Console.WriteLine($"Application :: Result of {method} is \n {table}\n");

            }

            Environment.Exit(0);
        }

    }
}
