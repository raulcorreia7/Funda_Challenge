using System.Globalization;
using Serilog;
using Serilog.Configuration;
using Serilog.Core;
using Serilog.Events;

namespace FundaAPIClient
{

    public class Logger
    {
        private static LoggingLevelSwitch levelswitch = null;
        public Logger()
        {
        }


        public static void RegisterLogger(ILogger logger)
        {
            Log.Logger = logger;
        }

        public static void SetupDefaultLogger(LogEventLevel defaultLevel = LogEventLevel.Information)
        {
            levelswitch = new LoggingLevelSwitch(defaultLevel);
            levelswitch.MinimumLevel = defaultLevel;
            Log.Logger = new LoggerConfiguration()
              .MinimumLevel.ControlledBy(levelswitch)
              .WriteTo.File("logs/client.log", rollingInterval: RollingInterval.Hour, fileSizeLimitBytes: null)
              .WriteTo.Console(restrictedToMinimumLevel: defaultLevel)
              .CreateLogger();
            Log.Debug("Logger :: Initialized logger.");
        }
    }
}