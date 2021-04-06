using System;
using System.Collections.Generic;
using System.Linq;
using Serilog;
using Xunit;
using Xunit.Abstractions;

namespace FundaAPIClient.Tests
{

    public class FundaAPIClientRestAPITests
    {

        public FundaAPIClientRestAPITests(ITestOutputHelper output)
        {
            LoggerSetup.SetupLoggerForTest(output, nameof(FundaAPIClientRestAPITests));
        }

        /// <summary>
        /// Use FundaAPIClient with cached data locally to validate integration test
        ///  All Amsterdam data
        /// </summary>
        [Fact]
        public void FundaAPIClientRestAPIGetTop10()
        {
            #region Scenario Setup
            IFundaAPIClient fundaAPIClient = new FundaAPIClient();

            fundaAPIClient.AddCrawler(new CrawlerFundaRestAPI());
            fundaAPIClient.AddDataProcessor(new FundaJsonDataProcessor());
            #endregion

            var results = fundaAPIClient.GetTop10Makelaars();

            Assert.NotNull(results);

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
            #endregion
        }


        /// <summary>
        /// Use FundaAPIClient with cached data locally to validate integration test
        ///  All Amsterdam data
        /// </summary>
        [Fact]
        public void FundaAPIClientRestAPIGetTop10WithTuin()
        {
            #region Scenario Setup
            IFundaAPIClient fundaAPIClient = new FundaAPIClient();

            fundaAPIClient.AddCrawler(new CrawlerFundaRestAPI());
            fundaAPIClient.AddDataProcessor(new FundaJsonDataProcessor());
            #endregion

            var results = fundaAPIClient.GetTop10MakelaarsWithTuin();

            Assert.NotNull(results);

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
            #endregion
        }

    }
}

