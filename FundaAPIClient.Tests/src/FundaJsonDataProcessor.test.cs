using System;
using System.Collections.Generic;
using System.Linq;
using Serilog;
using Xunit;
using Xunit.Abstractions;

namespace FundaAPIClient.Tests
{

    public class FundaJsonDataProcessorTests
    {


        public FundaJsonDataProcessorTests(ITestOutputHelper output)
        {
            LoggerSetup.SetupLoggerForTest(output);

        }

        /// <summary>
        ///  Purpose of this test is validate the interaction between the written systems.
        ///  Using the local Crawler gives a validation of the other data layers.
        /// </summary>
        [Fact]
        public void ProcessLocalCrawlerDataSuccesfully()
        {
            #region Scenario Setup
            // Create Crawler
            ICrawlerAlgorithm crawlerAlgorithm = new CrawlerLocal();
            Dictionary<string, string> options = new Dictionary<string, string>();
            // Say we are using the Method Top10
            options[CrawlerConstants.MethodKey] = CrawlerConstants.MethodTop10;
            crawlerAlgorithm.Configure(options);

            // Run the Crawler
            var data = crawlerAlgorithm.Crawl();

            // Assert we have something
            Assert.NotNull(data);
            #endregion

            #region Data Processing
            // Instantiate a Data Processor for type Json
            IFundaDataProcessor dataProcessor = new FundaJsonDataProcessor();
            // Process the data
            var results = dataProcessor.ProcessData(data);

            Assert.NotNull(results);
            #endregion

            #region Assertion
            // Assertion of the order, so we garante that the List is ordered by Markelaar Object Count.
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

            // Quality of Life, outputting the Table
            var tableOutput = results.GetTableString();
            Log.Verbose(results.GetTableString());
            Assert.Contains("12285", tableOutput);
            Assert.Contains("Makelaarsland", tableOutput);
            Assert.Contains("24607", tableOutput);
            Assert.Contains("Kuijs Reinder Kakes Makelaars Amsterdam", tableOutput);

            #endregion
        }
    }
}
