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
              .WriteTo.File("logs/client_debug.log", rollingInterval: RollingInterval.Day, fileSizeLimitBytes: null, restrictedToMinimumLevel: Serilog.Events.LogEventLevel.Debug)
              .WriteTo.File("logs/client_verbose.log", rollingInterval: RollingInterval.Day, fileSizeLimitBytes: null, restrictedToMinimumLevel: Serilog.Events.LogEventLevel.Verbose)
              .CreateLogger();
        }
    }
}