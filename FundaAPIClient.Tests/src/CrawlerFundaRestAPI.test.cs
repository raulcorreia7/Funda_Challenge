using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;
using Xunit.Abstractions;

namespace FundaAPIClient.Tests
{

    public class CrwalerFundaRestAPITests
    {

        public CrwalerFundaRestAPITests(ITestOutputHelper output)
        {
            LoggerSetup.SetupLoggerForTest(output, nameof(CrwalerFundaRestAPITests));
        }

        // /// <summary>
        // /// Use Local Crawl algorithm locally to check our system is working with files in the hard disk.
        // /// </summary>
        // [Fact]
        // public void CrawlFundaAPIAllAmsterdamData()
        // {
        //     ICrawlerAlgorithm crawlerAlgorithm = new CrawlerFundaRestAPI();

        //     Dictionary<string, string> options = new Dictionary<string, string>();

        //     options[CrawlerConstants.MethodKey] = CrawlerConstants.MethodTop10;

        //     crawlerAlgorithm.Configure(options);

        //     var data = crawlerAlgorithm.Crawl();

        //     // assert we have something atleast
        //     Assert.NotNull(data);
        //     Assert.True(data.Data.Count > 0); // there are 5 json files read from disk

        //     // Number of pages
        //     int currentPage = data.Data.First().Paging.HuidigePagina.Value;
        //     int maxPages = data.Data.First().Paging.AantalPaginas.Value;

        //     Assert.Equal(maxPages, data.Data.Count);
        // }
    }
}
