using System;
using System.Collections.Generic;
using Xunit;
using Xunit.Abstractions;

namespace FundaAPIClient.Tests
{

    public class CrawerLocalTests
    {

        public CrawerLocalTests(ITestOutputHelper output)
        {
            LoggerSetup.SetupLoggerForTest(output);
        }

        /// <summary>
        /// Use Local Crawl algorithm locally to check our system is working with files in the hard disk.
        ///  All Amsterdam data
        /// </summary>
        [Fact]
        public void CrawlLocallyAllAmsterdamData()
        {
            #region Scenario Setup
            ICrawlerAlgorithm crawlerAlgorithm = new CrawlerLocal();
            Dictionary<string, string> options = new Dictionary<string, string>();
            options[CrawlerConstants.MethodKey] = CrawlerConstants.MethodTop10;
            crawlerAlgorithm.Configure(options);
            #endregion

            var data = crawlerAlgorithm.Crawl();

            // assert we have something atleast
            Assert.NotNull(data);
            Assert.True(data.Data.Count == 5); // there are 5 json files read from disk

            // Assert we have pages
            for (int i = 1; i <= 5; i++)
            {
                // by order
                Assert.True(data.Data[i - 1].Paging.HuidigePagina.Value == i);
                // exists the next link to crawl
                Assert.True(data.Data[i - 1].Paging.VolgendeUrl != null &&
                                            data.Data[i - 1].Paging.VolgendeUrl.Length > 0);
            }
        }


        /// <summary>
        /// Use Local Crawl algorithm locally to check our system is working with files in the hard disk.
        ///  All Amsterdam data w/ tuin
        /// </summary>
        [Fact]
        public void CrawlLocallyAllAmsterdamDataWithTuin()
        {
            #region Scenario Setup
            ICrawlerAlgorithm crawlerAlgorithm = new CrawlerLocal();
            Dictionary<string, string> options = new Dictionary<string, string>();
            options[CrawlerConstants.MethodKey] = CrawlerConstants.MethodTop10WithTuin;
            crawlerAlgorithm.Configure(options);
            #endregion

            var data = crawlerAlgorithm.Crawl();

            // assert we have something atleast
            Assert.NotNull(data);
            Assert.True(data.Data.Count == 5); // there are 5 json files read from disk

            // Assert we have pages
            for (int i = 1; i <= 5; i++)
            {
                // by order
                Assert.True(data.Data[i - 1].Paging.HuidigePagina.Value == i);
                // exists the next link to crawl
                Assert.True(data.Data[i - 1].Paging.VolgendeUrl != null &&
                                            data.Data[i - 1].Paging.VolgendeUrl.Length > 0);
            }

        }
    }
}
