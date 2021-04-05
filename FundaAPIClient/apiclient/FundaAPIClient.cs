using System.Collections.Generic;
using Serilog;

namespace FundaAPIClient
{
    public class FundaAPIClient : IFundaAPIClient
    {

        private ICrawlerAlgorithm CrawlerAlgorithm { get; set; } = null;

        private IFundaDataProcessor DataProcessor { get; set; } = null;
        public FundaAPIClient()
        {
            Log.Verbose("Instancing FundaAPIClient");
        }

        public FundaResults GetTop10Makelaars()
        {
            Log.Verbose($"FundaAPIClient :: Starting GetTop10Makelaars");
            Log.Verbose($"FundaAPIClient :: Starting Crawler");
            var rawdata = this.CrawlerAlgorithm.Crawl();
            Log.Verbose("FundaAPIClient :: Finished Crawler");
            Log.Verbose("FundaAPIClient :: Starting to process data.");
            var processedData = this.DataProcessor.ProcessData(rawdata);
            Log.Verbose("FundaAPIClient :: Finished data processing");
            return processedData;
        }

        public FundaResults GetTop10MakelaarsWithTuin()
        {
            Log.Verbose($"FundaAPIClient ::  Starting GetTop10Makelaars");
            Log.Verbose($"FundaAPIClient :: Starting Crawler");
            var rawdata = this.CrawlerAlgorithm.Crawl();
            Log.Verbose("FundaAPIClient :: Finished Crawler");
            Log.Verbose("FundaAPIClient :: Starting to process data.");
            var processedData = this.DataProcessor.ProcessData(rawdata);
            Log.Verbose("FundaAPIClient :: Finished data processing");
            return processedData;
        }

        public void AddCrawler(ICrawlerAlgorithm crawlerAlgorithm)
        {
            Log.Verbose("FundaAPIClient :: Adding a Crawler Algorithm");
            this.CrawlerAlgorithm = crawlerAlgorithm;
        }

        public void AddDataProcessor(IFundaDataProcessor dataProcessor)
        {
            Log.Verbose("FundaAPIClient :: Adding a Data Processor");
            this.DataProcessor = dataProcessor;
        }
    }
}