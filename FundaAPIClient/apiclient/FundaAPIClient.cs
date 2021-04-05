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

            Log.Debug("FundaAPIClient :: Configuring Crawler.");
            this.CrawlerAlgorithm.Configure(options);

            Log.Information($"FundaAPIClient :: Running Crawler.");
            var rawdata = this.CrawlerAlgorithm.Crawl();
            Log.Information("FundaAPIClient :: Finished Crawling.");

            if (!rawdata.IsDataComplete())
            {
                Log.Error("FundaAPIClient :: Crawling data was not able to gather all data!");
            }
            return rawdata;
        }

        private FundaResults ProcessData(FundaRawData rawData)
        {
            Log.Debug("FundaAPIClient :: Starting to process data.");

            if (!rawData.IsDataComplete())
            {
                Log.Error("FundaAPIClient :: Processing Incomplete Data!");
            }

            var processedData = this.DataProcessor.ProcessData(rawData);
            Log.Debug("FundaAPIClient :: Finished data processing");
            return processedData;
        }

        public FundaResults GetTop10Makelaars()
        {
            Log.Information($"FundaAPIClient :: Starting GetTop10Makelaars.");

            Dictionary<string, string> options = new Dictionary<string, string>();
            options[CrawlerConstants.MethodKey] = CrawlerConstants.MethodTop10;

            var rawData = this.RunCrawler(options);

            var processedData = this.ProcessData(rawData);
            Log.Information($"FundaAPIClient :: Ended GetTop10Makelaars.");

            return processedData;
        }

        public FundaResults GetTop10MakelaarsWithTuin()
        {

            Log.Information($"FundaAPIClient :: Starting GetTop10MakelaarsWithTuin.");

            Dictionary<string, string> options = new Dictionary<string, string>();
            options[CrawlerConstants.MethodKey] = CrawlerConstants.MethodTop10;

            var rawData = this.RunCrawler(options);

            var processedData = this.ProcessData(rawData);

            Log.Information($"FundaAPIClient :: Ended GetTop10MakelaarsWithTuin.");
            return processedData;
        }

        public void AddCrawler(ICrawlerAlgorithm crawlerAlgorithm)
        {
            Log.Debug("FundaAPIClient :: Adding a Crawler Algorithm.");
            this.CrawlerAlgorithm = crawlerAlgorithm;
        }

        public void AddDataProcessor(IFundaDataProcessor dataProcessor)
        {
            Log.Debug("FundaAPIClient :: Adding a Data Processor.");
            this.DataProcessor = dataProcessor;
        }
    }
}