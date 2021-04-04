using System.Collections.Generic;

namespace FundaAPIClient
{

    /// <summary>
    /// Interface for a Crawler Algorithm
    /// </summary>
    public interface ICrawlerAlgorithm
    {

        /// <summary>
        /// Configure Crawler
        /// 
        ///  Given the Requirements all crawlers will use these Key Value Pairs.
        ///  Key : Value
        /// {
        ///    "Method" : "Top10" or "Top10WithTuin"
        /// }
        /// Please use Crawler Constants.
        /// </summary>
        /// <param name="options">Dictionary with Key Value pair to configure Crawler.</param>
        void Configure(Dictionary<string, string> options);

        /// <summary>
        /// Run Crawler
        /// </summary>
        /// <returns>
        /// FundaData with all the data from the Funda API
        /// </returns>
        FundaRawData Crawl();
    }

}