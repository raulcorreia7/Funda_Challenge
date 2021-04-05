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

        private FundaRawData RunCrawler(Dictionary<string, string> options)
        {

            Log.Verbose("FundaAPIClient :: Starting to configure Crawler");
            this.CrawlerAlgorithm.Configure(options);

            Log.Debug($"FundaAPIClient :: Starting Crawler");
            var rawdata = this.CrawlerAlgorithm.Crawl();
            Log.Debug("FundaAPIClient :: Finished Crawler");

            return rawdata;
        }

        private FundaResults ProcessData(FundaRawData rawData)
        {
            Log.Debug("FundaAPIClient :: Starting to process data.");
            var processedData = this.DataProcessor.ProcessData(rawData);
            Log.Debug("FundaAPIClient :: Finished data processing");
            return processedData;
        }

        public FundaResults GetTop10Makelaars()
        {
            Log.Debug($"FundaAPIClient :: Starting GetTop10Makelaars");

            Dictionary<string, string> options = new Dictionary<string, string>();
            options[CrawlerConstants.MethodKey] = CrawlerConstants.MethodTop10;

            var rawData = this.RunCrawler(options);

            var processedData = this.ProcessData(rawData);

            return processedData;
        }

        public FundaResults GetTop10MakelaarsWithTuin()
        {

            Log.Debug($"FundaAPIClient :: Starting GetTop10MakelaarsWithTuin");

            Dictionary<string, string> options = new Dictionary<string, string>();
            options[CrawlerConstants.MethodKey] = CrawlerConstants.MethodTop10;

            var rawData = this.RunCrawler(options);

            var processedData = this.ProcessData(rawData);

            return processedData;
        }

        public void AddCrawler(ICrawlerAlgorithm crawlerAlgorithm)
        {
            Log.Debug("FundaAPIClient :: Adding a Crawler Algorithm");
            this.CrawlerAlgorithm = crawlerAlgorithm;
        }

        public void AddDataProcessor(IFundaDataProcessor dataProcessor)
        {
            Log.Debug("FundaAPIClient :: Adding a Data Processor");
            this.DataProcessor = dataProcessor;
        }
    }
}