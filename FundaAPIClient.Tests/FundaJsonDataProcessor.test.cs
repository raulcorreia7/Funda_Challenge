using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;
using Xunit.Abstractions;

namespace FundaAPIClient.Tests
{

    public class FundaJsonDataProcessorTests
    {
        private readonly ITestOutputHelper Output;

        public FundaJsonDataProcessorTests(ITestOutputHelper output)
        {
            this.Output = output;
        }

        [Fact]
        public void ProcessLocalCrawlerSuccesfully()
        {
            #region Scenario Setup
            ICrawlerAlgorithm crawlerAlgorithm = new CrawlerLocal();
            Dictionary<string, string> options = new Dictionary<string, string>();
            options[CrawlerConstants.MethodKey] = CrawlerConstants.MethodTop10;
            crawlerAlgorithm.Configure(options);
            var data = crawlerAlgorithm.Crawl();
            Assert.NotNull(data);
            #endregion

            IFundaDataProcessor dataProcessor = new FundaJsonDataProcessor();
            var results = dataProcessor.ProcessData(data);

            Assert.NotNull(results);
            // Assert order
            int previousValue = -1;
            foreach (var makelar in results.Results)
            {
                if (previousValue == -1)
                {
                    previousValue = makelar.Count;
                    continue;
                }
                Assert.True(previousValue >= makelar.Count, "Processing the results is not producing a ordered list");
                previousValue = makelar.Count;
            }
            Assert.True(results.GetTop10().Count() == 10, "There should be exactly 10 elements in the results.");

            var tableOutput = results.GetTableString();
            Output.WriteLine(results.GetTableString());
            Assert.True(tableOutput.Contains("12285"));
            Assert.True(tableOutput.Contains("Makelaarsland"));
            Assert.True(tableOutput.Contains("24607"));
            Assert.True(tableOutput.Contains("Kuijs Reinder Kakes Makelaars Amsterdam"));
        }
    }
}
