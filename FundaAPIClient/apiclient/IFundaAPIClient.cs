using System.Collections.Generic;

namespace FundaAPIClient
{
    /// <summary>
    /// Interface for the FundaAPIClient
    /// </summary>
    public interface IFundaAPIClient
    {
        /// <summary>
        ///  High level function to get the Top10 Makelaars.
        /// </summary>
        /// <returns>FundaResults - With Top10 Makelaars for Amsterdam</returns>
        FundaResults GetTop10Makelaars();

        /// <summary>
        ///  High level function to get Top10 Makelaars with Tuin (Garden)
        /// </summary>
        /// <returns>FundaResults - With Top10 Makelaars for Amsterdam</returns>
        FundaResults GetTop10MakelaarsWithTuin();

        /// <summary>
        /// Add a Crawler Algorithm to the FundaAPIClient
        /// The point of this interface is to use a Local Crawler with cached data for validation and testing purposes
        ///  or
        /// The actually final RestAPI Implementation.
        /// </summary>
        /// <param name="crawlerAlgorithm">The algorithm as a parameter to pass</param>
        void AddCrawler(ICrawlerAlgorithm crawlerAlgorithm);

        /// <summary>
        /// Add a DataProcessor to the FundaAPIClient.
        /// The point of this interface is to decouple from which datatype we process from Funda.
        ///  Funda provides two dataypes:
        ///    * XML
        ///    * JSON
        ///  With this Layer of the indirection i believe we can handle both (and more if needed).
        /// </summary>
        /// <param name="dataProcessor">Data Processor for a custom Data Type</param>
        void AddDataProcessor(IFundaDataProcessor dataProcessor);
    }

}