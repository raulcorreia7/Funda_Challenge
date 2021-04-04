using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using FundaAPIClient;

namespace FundaAPIClient
{
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

        private FundaData CrawlerData { get; set; } = null;

        private void ReadAllAmsterdamData()
        {
            CrawlerData = new FundaData();

            #region read all amsterdam data
            DirectoryInfo dinfo = new DirectoryInfo(ALL_AMSTERDAM_FOLDER);
            FileInfo[] amsterdam_all = dinfo.GetFiles("*.json");

            foreach (FileInfo f in amsterdam_all)
            {
                String contents = File.ReadAllText(f.FullName);
                CrawlerData.ParseJson(contents);
            }
            #endregion
        }
        private void ReadAmsterdamTuinData()
        {
            CrawlerData = new FundaData();

            #region read all amstermdam tuin data
            DirectoryInfo dinfo = new DirectoryInfo(ALL_AMSTERDAM_WITH_TUIN_FOLDER);
            FileInfo[] amsterdam_tuin = dinfo.GetFiles("*.json");

            foreach (FileInfo f in amsterdam_tuin)
            {
                String contents = File.ReadAllText(f.FullName);
                CrawlerData.ParseJson(contents);
            }
            #endregion

        }


        public FundaData Crawl()
        {
            return CrawlerData;
        }

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