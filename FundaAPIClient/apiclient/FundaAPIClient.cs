using System.Collections.Generic;

namespace FundaAPIClient
{
    public class FundaAPIClient : IFundaAPIClient
    {

        private ICrawlerAlgorithm CrawlerAlgorithm { get; set; } = null;

        public FundaAPIClient()
        {
        }

        public FundaData GetTop10Makelaars()
        {
            throw new System.NotImplementedException();
        }

        public FundaData GetTop10MakelaarsWithTuin()
        {
            throw new System.NotImplementedException();
        }

        public FundaData Run()
        {

            return null;
        }

        public void AddCrawler(ICrawlerAlgorithm crawlerAlgorithm)
        {
            this.CrawlerAlgorithm = crawlerAlgorithm;
        }
    }
}