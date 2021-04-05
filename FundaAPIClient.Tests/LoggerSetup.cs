using System;
using Serilog;
using Xunit;
using Xunit.Abstractions;

namespace FundaAPIClient.Tests
{
    public class LoggerSetup
    {
        public static void SetupLoggerForTest(ITestOutputHelper output)
        {
            Log.Logger = new LoggerConfiguration()
            .MinimumLevel.Verbose()
            .WriteTo.TestOutput(output, Serilog.Events.LogEventLevel.Verbose)
            .WriteTo.File("logs/client.log", rollingInterval: RollingInterval.Day, fileSizeLimitBytes: null)
            .CreateLogger();
        }
    }
}
