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
        private void ReadAllData()
        {

            CrawlerData = new FundaData();

            DirectoryInfo dinfo = new DirectoryInfo(ALL_AMSTERDAM_FOLDER);
            FileInfo[] amsterdam_all = dinfo.GetFiles("*.json");


            dinfo = new DirectoryInfo(ALL_AMSTERDAM_WITH_TUIN_FOLDER);
            FileInfo[] amsterdam_tuin = dinfo.GetFiles("*.json");



        }
        public FundaData Crawl()
        {
            throw new System.NotImplementedException();
        }
    }
}