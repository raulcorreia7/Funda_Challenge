using System.Collections.Generic;

namespace FundaAPIClient
{
    public class FundaAPIClient : IFundaAPIClient
    {

        private ICrawlerAlgorithm CrawlerAlgorithm { get; set; } = null;

        private IFundaDataProcessor DataProcessor { get; set; } = null;
        public FundaAPIClient()
        {
        }

        public FundaResults GetTop10Makelaars()
        {
            
            var rawdata = this.CrawlerAlgorithm.Crawl();
            var processedData = this.DataProcessor.ProcessData(rawdata);
            return processedData;
        }

        public FundaResults GetTop10MakelaarsWithTuin()
        {
            throw new System.NotImplementedException();
        }

        public void AddCrawler(ICrawlerAlgorithm crawlerAlgorithm)
        {
            this.CrawlerAlgorithm = crawlerAlgorithm;
        }

        public void AddDataProcessor(IFundaDataProcessor dataProcessor)
        {
            this.DataProcessor = dataProcessor;
        }
    }
}