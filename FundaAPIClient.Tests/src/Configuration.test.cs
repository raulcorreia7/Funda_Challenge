using Xunit;
using Xunit.Abstractions;

namespace FundaAPIClient.Tests
{
    public class ConfigurationTests
    {

        public ConfigurationTests(ITestOutputHelper output)
        {
            LoggerSetup.SetupLoggerForTest(output);
        }
        
        [Fact]
        public void TestConfigFileIsGood()
        {
            Configuration config = Configuration.LoadConfiguration();

            // Assert configuration exists
            Assert.NotNull(config);

            // Assert BaseUrl exists and not empty
            Assert.NotNull(config.BaseUrl);
            Assert.True(config.BaseUrl.Length > 0);

            // Assert APIKey exists and not empty
            Assert.NotNull(config.APIKey);
            Assert.True(config.APIKey.Length > 0);

            // Assert Query exists and not empty
            Assert.NotNull(config.Query);
            Assert.True(config.Query.Length > 0);
        }
    }
}