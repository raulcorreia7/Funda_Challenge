using System.Collections.Generic;
using Serilog;

namespace FundaAPIClient
{
    /// <summary>
    /// Implemention of the FundaAPIClient.
    /// </summary>
    public class FundaAPIClient : IFundaAPIClient
    {
        /// <summary>
        /// Algorithm that will perform the crawling
        /// </summary>
        private ICrawlerAlgorithm CrawlerAlgorithm { get; set; } = null;

        /// <summary>
        /// Data Processor, to process data once complete.
        /// </summary>
        private IFundaDataProcessor DataProcessor { get; set; } = null;
        public FundaAPIClient()
        {
            Log.Verbose("Instancing FundaAPIClient");
        }


        /// <summary>
        /// Common code to Configure and Run the Crawler.
        /// </summary>
        /// <param name="options">Configurations for the Cawler</param>
        /// <returns>Data with the result of crawling.</returns>
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

        /// <summary>
        /// Process Data common code.
        /// </summary>
        /// <param name="rawData">Raw data passed in.</param>
        /// <returns>Processed data out.</returns>
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

        /// <summary>
        /// Get Top10 Makelaars Requirement.
        /// Gets all Amsterdam Data, processes it and returns it.
        /// </summary>
        /// <returns>Processed data</returns>
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

        // <summary>
        /// Get Top10 Makelaars with Tuin Requirement.
        /// Gets all Amsterdam Data with Tuins, processes it and returns it.
        /// </summary>
        /// <returns>Processed data</returns>
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

        /// <summary>
        /// Add a Crawler to the FundaAPIClient
        /// </summary>
        /// <param name="crawlerAlgorithm">Crawler to add</param>
        public void AddCrawler(ICrawlerAlgorithm crawlerAlgorithm)
        {
            Log.Debug("FundaAPIClient :: Adding a Crawler Algorithm.");
            this.CrawlerAlgorithm = crawlerAlgorithm;
        }

        /// <summary>
        /// Add a DataProcessor to the FundaAPIClient
        /// </summary>
        /// <param name="dataProcessor">DataProcessor to add</param>
        public void AddDataProcessor(IFundaDataProcessor dataProcessor)
        {
            Log.Debug("FundaAPIClient :: Adding a Data Processor.");
            this.DataProcessor = dataProcessor;
        }
    }
}