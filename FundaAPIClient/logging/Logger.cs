using Serilog;

namespace FundaAPIClient
{
    public class Logger
    {
        public Logger()
        {
        }


        public static void RegisterLogger(ILogger logger)
        {
            Log.Logger = logger;
        }

        public static void SetupDefaultLogger()
        {
            Log.Logger = new LoggerConfiguration()
              .MinimumLevel.Debug()
              .WriteTo.Console()
              .WriteTo.File("logs/client.log", rollingInterval: RollingInterval.Day, fileSizeLimitBytes: null)
              .CreateLogger();
        }
    }
}