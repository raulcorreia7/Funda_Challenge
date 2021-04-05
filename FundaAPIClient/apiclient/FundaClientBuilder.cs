using Serilog;

namespace FundaAPIClient
{

    /// <summary>
    /// builder for FundaAPIClient
    /// </summary>
    public class FundaClientBuilder
    {
        /// <summary>
        /// FundaAPIClient Instance
        /// </summary>
        public IFundaAPIClient Instance { get; set; } = new FundaAPIClient();

        /// <summary>
        ///  Reset the FundaAPIClient Instance
        /// </summary>
        /// <returns>Current Builder</returns>
        public FundaClientBuilder Reset()
        {
            Log.Debug("FundaClientBuilder :: Resetting FundaAPIClient Instance");
            this.Instance = new FundaAPIClient();
            return this;
        }

        /// <summary>
        ///  Add a RestAPI Crawler to the FundaAPI Client
        /// </summary>
        /// <returns>Current Builder</returns>
        public FundaClientBuilder WithRestAPICrawler()
        {
            Log.Debug("FundaClientBuilder :: Adding RestAPI Crawler");
            this.Instance.AddCrawler(new CrawlerFundaRestAPI());
            return this;
        }


        /// <summary>
        ///  Add a RestAPI Crawler to the FundaAPI Client
        /// </summary>
        /// <returns>Current Builder</returns>
        public FundaClientBuilder WithLocalCrawler()
        {
            Log.Debug("FundaClientBuilder :: Adding Local Crawler");
            this.Instance.AddCrawler(new CrawlerLocal());
            return this;
        }

        /// <summary>
        ///  Add a Json Data processor to the FundaAPI Client
        /// </summary>
        /// <returns>Current Builder</returns>
        public FundaClientBuilder WithFundaJsonDataProcessor()
        {
            Log.Debug("FundaClientBuilder :: Adding Funda Json Data Processor");
            this.Instance.AddDataProcessor(new FundaJsonDataProcessor());
            return this;
        }


        /// <summary>
        /// Build the Instance
        /// </summary>
        /// <returns>The FundaAPIClient Instance</returns>
        public IFundaAPIClient Build()
        {
            Log.Debug("FundaClientBuilder :: Building the Funda API Client Instance");
            return this.Instance;
        }

    }
}