using System;
using System.IO;
using Newtonsoft.Json;
using Xunit;
using Xunit.Abstractions;

namespace FundaAPIClient.Tests
{

    public class FundaJSONTests
    {

        public FundaJSONTests(ITestOutputHelper output)
        {
            LoggerSetup.SetupLoggerForTest(output, nameof(FundaJSONTests));
        }

        /// <summary>
        /// Parse the json file "assets/amsterdam_all/p1.json" and do some sanity check.
        /// The goal of this test is to understand if our Selerization/Deselirization works properly.
        /// 
        /// </summary>
        [Fact]
        public void SucessfullyParseLocalJsonDataAllAmsterdam()
        {
            FundaJSON json = JsonConvert.DeserializeObject<FundaJSON>(File.ReadAllText(CrawlerLocal.ALL_AMSTERDAM_FOLDER + "/p1.json"));

            // Assert we have a succesfull deserialization
            Assert.NotNull(json);


            // Assert we have Ads for the houses
            Assert.NotNull(json.Objects);
            Assert.True(json.Objects.Capacity > 0);

            // Let's test that we have MakelaarNaam and Id
            foreach (Object obj in json.Objects)
            {
                Assert.NotNull(obj.MakelaarNaam);
                Assert.NotNull(obj.MakelaarId);
            }

            // Let's assert we have Paging so we can crawl
            Assert.NotNull(json.Paging);
            Assert.NotNull(json.Paging.AantalPaginas);
            Assert.NotNull(json.Paging.HuidigePagina);
            Assert.NotNull(json.Paging.VolgendeUrl);

            // Let's assert There are actually pages
            Assert.True(json.Paging.AantalPaginas > 0);
            Assert.True(json.Paging.HuidigePagina > 0);

            // Let's assert there is a string to crawl next
            Assert.True(json.Paging.VolgendeUrl.Length > 0);

        }

        /// <summary>
        /// Parse the json file "assets/amsterdam_tuin/p1.json" and do some sanity check.
        /// The goal of this test is to understand if our Selerization/Deselirization works properly.
        /// 
        /// </summary>
        [Fact]
        public void SucessfullyParseLocalJsonDataAmsterdamTuin()
        {
            FundaJSON json = JsonConvert.DeserializeObject<FundaJSON>(File.ReadAllText(CrawlerLocal.ALL_AMSTERDAM_WITH_TUIN_FOLDER + "/p1.json"));

            // Assert we have a succesfull deserialization
            Assert.NotNull(json);

            // Assert we have Ads for the houses
            Assert.NotNull(json.Objects);
            Assert.True(json.Objects.Capacity > 0);

            // Let's test that we have MakelaarNaam and Id
            foreach (Object obj in json.Objects)
            {
                Assert.NotNull(obj.MakelaarNaam);
                Assert.NotNull(obj.MakelaarId);
            }

            // Let's assert we have Paging so we can crawl
            Assert.NotNull(json.Paging);
            Assert.NotNull(json.Paging.AantalPaginas);
            Assert.NotNull(json.Paging.HuidigePagina);
            Assert.NotNull(json.Paging.VolgendeUrl);

            // Let's assert There are actually pages
            Assert.True(json.Paging.AantalPaginas > 0);
            Assert.True(json.Paging.HuidigePagina > 0);

            // Let's assert there is a string to crawl next
            Assert.True(json.Paging.VolgendeUrl.Length > 0);

        }
    }
}
