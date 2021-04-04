using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using FundaAPIClient;

namespace FundaAPIClient
{

    /// <summary>
    /// This is a Local Crawler for Funda JSON Data.
    /// The purpose of this class is to validate the whole system with a cached files, 
    /// decoupling the system with online API calls limitation and giving a early fail fast validation layer.
    /// </summary>
    public class CrawlerLocal : ICrawlerAlgorithm
    {
        /// <summary>
        /// PageSize of Funda Json Files
        /// </summary>
        public const int PageSize = 25;

        /// <summary>
        /// Folder with cached files for 5 pages of makelaars on amsterdam
        /// </summary>
        public const string ALL_AMSTERDAM_FOLDER = "assets/amsterdam_all/";

        /// <summary>
        /// Folder with cached files for 5 pages of makelaars on amsterdam with tuins
        /// </summary>
        public const string ALL_AMSTERDAM_WITH_TUIN_FOLDER = "assets/amsterdam_tuin/";

        /// <summary>
        /// CrawlerData
        /// </summary>
        /// <value></value>
        private FundaRawData CrawlerData { get; set; } = null;

        /// <summary>
        /// Common Json Code Path.
        /// Reads Json and Parses it.
        /// </summary>
        /// <param name="folderPath">folder pointing to funda json files.</param>
        private void ReadJsonFiles(string folderPath)
        {
            CrawlerData = new FundaRawData();

            #region read all json data
            DirectoryInfo dinfo = new DirectoryInfo(folderPath);
            FileInfo[] amsterdam_all = dinfo.GetFiles("*.json");

            foreach (FileInfo f in amsterdam_all)
            {
                String contents = File.ReadAllText(f.FullName);
                CrawlerData.ParseJson(contents);
            }
            #endregion
        }

        /// <summary>
        /// Reads Data for all Makelaars for Amsterdam
        /// </summary>
        private void ReadAllAmsterdamData()
        {
            ReadJsonFiles(ALL_AMSTERDAM_FOLDER);
        }

        /// <summary>
        /// Reads Data for all Makelaars for Amsterdam with Tuin
        /// </summary>
        private void ReadAmsterdamTuinData()
        {
            ReadJsonFiles(ALL_AMSTERDAM_WITH_TUIN_FOLDER);
        }

        /// <summary>
        /// Crawl command
        /// </summary>
        /// <returns>Crawler Data</returns>
        public FundaRawData Crawl()
        {
            return CrawlerData;
        }
        /// <summary>
        /// Configure Crawler
        /// 
        /// LocalCrawler uses the following options:
        ///  Key : Value
        /// {
        ///    "Method" : "Top10" or "Top10WithTuin"
        /// }
        /// Please use Crawler Constants.
        /// </summary>
        /// <param name="options">Dictionary with Key Value pair to configure Crawler.</param>
        public void Configure(Dictionary<string, string> options)
        {
            if (options.ContainsKey(CrawlerConstants.MethodKey))
            {
                if (options[CrawlerConstants.MethodKey] == CrawlerConstants.MethodTop10WithTuin)
                {
                    this.ReadAmsterdamTuinData();
                }
                else if (options[CrawlerConstants.MethodKey] == CrawlerConstants.MethodTop10)
                {
                    this.ReadAllAmsterdamData();
                }
            }
        }
    }
}