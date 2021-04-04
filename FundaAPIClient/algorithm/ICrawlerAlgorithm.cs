using System.Collections.Generic;

namespace FundaAPIClient
{


    public interface ICrawlerAlgorithm
    {

        /// <summary>
        /// Configure Crawler options
        /// </summary>
        /// <param name="options"></param>
        void Configure(Dictionary<string, string> options);

        /// <summary>
        /// Run Crawler
        /// </summary>
        /// <returns>
        /// FundaData with all the data from the Funda API
        /// </returns>
        FundaData Crawl();
    }

}