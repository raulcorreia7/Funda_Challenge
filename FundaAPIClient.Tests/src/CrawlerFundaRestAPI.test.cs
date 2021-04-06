using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;
using Xunit.Abstractions;

namespace FundaAPIClient.Tests
{

    public class CrawlerFundaRestAPITests
    {

        public CrawlerFundaRestAPITests(ITestOutputHelper output)
        {
            LoggerSetup.SetupLoggerForTest(output, nameof(CrawlerFundaRestAPITests));
        }

        /// <summary>
        /// Use Local Crawl algorithm locally to check our system is working with files in the hard disk.
        /// </summary>
        [Fact]
        public void CrawlFundaAPIAllAmsterdamData()
        {
            #region Scenario Setup
            ICrawlerAlgorithm crawlerAlgorithm = new CrawlerFundaRestAPI();
            Dictionary<string, string> options = new Dictionary<string, string>();
            options[CrawlerConstants.MethodKey] = CrawlerConstants.MethodTop10;
            crawlerAlgorithm.Configure(options);
            var data = crawlerAlgorithm.Crawl();
            #endregion

            #region Assertion
            // assert we have something atleast
            Assert.NotNull(data);
            Assert.True(data.Data.Count > 0); // there are json files crawled

            // Number of pages
            int currentPage = data.GetCurrentPage();
            int maxPages = data.GetPageLimit();

            // Asserting that the number of pages is equal
            Assert.True(maxPages == data.Data.Count, "The number of pages is not equal, we didn't crawl sucessfully.");
            #endregion
        }

        /// <summary>
        /// Use Local Crawl algorithm locally to check our system is working with files in the hard disk.
        /// </summary>
        [Fact]
        public void CrawlFundaAPIAllAmsterdamWithTuinData()
        {
            #region Scenario Setup
            ICrawlerAlgorithm crawlerAlgorithm = new CrawlerFundaRestAPI();
            Dictionary<string, string> options = new Dictionary<string, string>();
            options[CrawlerConstants.MethodKey] = CrawlerConstants.MethodTop10WithTuin;
            crawlerAlgorithm.Configure(options);
            var data = crawlerAlgorithm.Crawl();
            #endregion

            #region Assertion
            // assert we have something atleast
            Assert.NotNull(data);
            Assert.True(data.Data.Count > 0); // there are json files crawled

            // Number of pages
            int currentPage = data.GetCurrentPage();
            int maxPages = data.GetPageLimit();

            // Asserting that the number of pages is equal
            Assert.True(maxPages == data.Data.Count, "The number of pages is not equal, we didn't crawl sucessfully.");
            #endregion
        }
    }
}
