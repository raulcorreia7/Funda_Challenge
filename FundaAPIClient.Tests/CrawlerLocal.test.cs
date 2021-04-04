using System;
using System.Collections.Generic;
using Xunit;

namespace FundaAPIClient.Tests
{

    public class CrawerLocalTests
    {
        [Fact]
        public void CrawlLocallyAllAmsterdamData()
        {
            ICrawlerAlgorithm crawlerAlgorithm = new CrawlerLocal();

            Dictionary<string, string> options = new Dictionary<string, string>();

            options[CrawlerConstants.MethodKey] = CrawlerConstants.MethodTop10;

            crawlerAlgorithm.Configure(options);

            var data = crawlerAlgorithm.Crawl();

            // assert we have something atleast
            Assert.NotNull(data);
            Assert.True(data.Files.Count == 5); // there are 5 json files read from disk

            // Assert we have pages
            for (int i = 1; i <= 5; i++)
            {
                // by order
                Assert.True(data.Files[i - 1].Paging.HuidigePagina.Value == i);
                // exists the next link to crawl
                Assert.True(data.Files[i - 1].Paging.VolgendeUrl != null &&
                                            data.Files[i - 1].Paging.VolgendeUrl.Length > 0);
            }

        }
    }
}
