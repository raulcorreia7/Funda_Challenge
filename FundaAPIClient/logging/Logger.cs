using System.Globalization;
using Serilog;
using Serilog.Configuration;
using Serilog.Core;
using Serilog.Events;

namespace FundaAPIClient
{

    public class Logger
    {
        private static LoggingLevelSwitch levelSwitch = null;
        public Logger()
        {
        }


        public static void RegisterLogger(ILogger logger)
        {
            Log.Logger = logger;
        }

        public static void SetupDefaultLogger(LogEventLevel defaultLevel = LogEventLevel.Debug)
        {
            levelSwitch = new LoggingLevelSwitch(defaultLevel);
            Log.Logger = new LoggerConfiguration()
              .WriteTo.File("logs/client_debug.log", rollingInterval: RollingInterval.Hour, fileSizeLimitBytes: null, restrictedToMinimumLevel: Serilog.Events.LogEventLevel.Debug)
              .WriteTo.File("logs/client_verbose.log", rollingInterval: RollingInterval.Hour, fileSizeLimitBytes: null, restrictedToMinimumLevel: Serilog.Events.LogEventLevel.Verbose)
              .WriteTo.Console(restrictedToMinimumLevel: defaultLevel)
              .CreateLogger();

            Log.Debug("Logger :: Initialized logger.");
        }
    }
}