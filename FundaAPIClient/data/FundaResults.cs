using System.Collections.Generic;
using System.Linq;
using ConsoleTables;
using Serilog;
using Serilog.Events;

namespace FundaAPIClient
{
    /// <summary>
    /// Class with post-processed information for the challenge.
    /// </summary>
    public class FundaResults
    {
        /// <summary>
        /// List of Makelaars
        /// </summary>
        public List<Makelaar> Results { get; set; }

        /// <summary>
        /// Gets the Top10 Makelaars.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Makelaar> GetTop10()
        {
            Log.Debug("FundaResults :: Getting Top 10 Makelaars");
            var results = this.Results.Take(10);
            if (Log.IsEnabled(LogEventLevel.Verbose))
            {
                Log.Verbose($"FundaResults :: Getting Top 10 Makelaars Results : {results}");
            }
            return results;
        }

        /// <summary>
        ///  Gets the String representing the Top10 Table, for testing purposes.
        /// </summary>
        /// <returns>String representing the Table</returns>
        public string GetTableString()
        {
            Log.Debug("FundaResults :: Getting Table String");
            var table = new ConsoleTable("Makelaar", "Objects");

            return ConsoleTable
                .From<Makelaar>(this.GetTop10())
                .Configure(o => o.NumberAlignment = Alignment.Right)
                .ToStringAlternative();
        }

        /// <summary>
        ///  Prints the Top10 Table.
        /// </summary>
        /// <returns>String representing the Table</returns>
        public void PrintTable()
        {
            Log.Debug("FundaResults :: Printing Table");
            var table = new ConsoleTable("Makelaar", "Objects");

            ConsoleTable
                .From<Makelaar>(this.GetTop10())
                .Configure(o => o.NumberAlignment = Alignment.Right)
                .Write();
        }
    }

}