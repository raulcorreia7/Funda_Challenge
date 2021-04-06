using System.Globalization;
using Serilog;
using Serilog.Configuration;
using Serilog.Core;
using Serilog.Events;

namespace FundaAPIClient
{

    /// <summary>
    ///  Logger Utility Class
    /// </summary>
    public class Logger
    {

        /// <summary>
        /// Switch to change logging level dynamically
        /// </summary>
        private static LoggingLevelSwitch levelswitch = null;
        public Logger()
        {
        }

        /// <summary>
        /// Construct a Logger with safe defaults
        /// </summary>
        /// <param name="defaultLevel">Minimum level to log.</param>
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