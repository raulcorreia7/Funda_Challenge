using System;
using Serilog;
using Serilog.Core;
using Serilog.Events;
using Xunit;
using Xunit.Abstractions;

namespace FundaAPIClient.Tests
{
    public class LoggerSetup
    {
        public static void SetupLoggerForTest(ITestOutputHelper output, string testClassName)
        {
            Log.Logger = new LoggerConfiguration()
            .MinimumLevel.Verbose()
            .WriteTo.TestOutput(output, Serilog.Events.LogEventLevel.Debug)
            .WriteTo.File($"logs/{testClassName}_verbose.log", rollingInterval: RollingInterval.Day, fileSizeLimitBytes: null, restrictedToMinimumLevel: LogEventLevel.Verbose)
            .WriteTo.File($"logs/{testClassName}_debug.log", rollingInterval: RollingInterval.Day, fileSizeLimitBytes: null, restrictedToMinimumLevel: LogEventLevel.Debug)
            .WriteTo.File($"logs/{testClassName}_information.log", rollingInterval: RollingInterval.Day, fileSizeLimitBytes: null, restrictedToMinimumLevel: LogEventLevel.Information)
            .CreateLogger();
        }
    }
}
