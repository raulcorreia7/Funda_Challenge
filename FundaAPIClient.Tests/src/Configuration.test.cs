using Xunit;
using Xunit.Abstractions;

namespace FundaAPIClient.Tests
{
    public class ConfigurationTests
    {

        public ConfigurationTests(ITestOutputHelper output)
        {
            LoggerSetup.SetupLoggerForTest(output, nameof(ConfigurationTests));
        }

        [Fact]
        public void TestConfigFileIsGood()
        {
            #region Scenario Setup
            Configuration config = Configuration.LoadConfiguration();
            #endregion

            #region Assertion
            // Assert configuration exists
            Assert.NotNull(config);

            // Assert APIKey exists and not empty
            Assert.NotNull(config.APIKey);
            Assert.True(config.APIKey.Length > 0);
            #endregion
        }
    }
}
