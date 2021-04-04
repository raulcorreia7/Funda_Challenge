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

            options["Method"] = "Top10";

            crawlerAlgorithm.Configure(options);

            var data = crawlerAlgorithm.Crawl();

            Assert.NotNull(data);
        }
    }
}
