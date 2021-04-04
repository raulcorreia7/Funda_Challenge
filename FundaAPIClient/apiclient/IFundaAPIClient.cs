using System.Collections.Generic;

namespace FundaAPIClient
{
    public interface IFundaAPIClient
    {
        FundaResults GetTop10Makelaars();

        FundaResults GetTop10MakelaarsWithTuin();

        /// <summary>
        /// Add a Crawler Algorithm to the FundaAPIClient
        /// </summary>
        /// <param name="crawlerAlgorithm">The algorithm as a parameter to pass</param>
        void AddCrawler(ICrawlerAlgorithm crawlerAlgorithm);
    }

}