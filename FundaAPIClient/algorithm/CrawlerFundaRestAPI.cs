using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Text.Json;
using System.Threading;
using FundaAPIClient;
using RestSharp;

namespace FundaAPIClient
{

    /// <summary>
    /// This is a Local Crawler for Funda JSON Data.
    /// The purpose of this class is to validate the whole system with a cached files, 
    /// decoupling the system with online API calls limitation and giving a early fail fast validation layer.
    /// </summary>
    public class CrawlerFundaRestAPI : ICrawlerAlgorithm
    {
        /// <summary>
        /// PageSize of Funda Json Files
        /// </summary>
        public const int PageSize = 25;

        private const string DataType = "json";

        /// <summary>
        /// CrawlerData
        /// </summary>
        private FundaRawData CrawlerData { get; set; } = null;


        private readonly RestClient restClient = new RestClient();

        /// <summary>
        /// Constructs a URL Query by replace the API Key, the DataType and With or without Tuin
        /// </summary>
        /// <param name="key">API Key</param>
        /// <param name="datatype">JSON or XML</param>
        /// <param name="withTuin">true or false</param>
        /// <returns>String with a URL to Query API Funda </returns>
        private string ConstructURLQuery(string key, string datatype, long pageIndex, bool withTuin)
        {
            string Query = CrawlerConstants.API_URL;

            var keysToReplace = new Dictionary<string, string>();
            keysToReplace["[datatype]"] = datatype;
            keysToReplace["[key]"] = key;
            keysToReplace["[pageindex]"] = pageIndex + "";
            keysToReplace["[tuin]"] = withTuin ? "tuin/" : "";


            foreach (var kv in keysToReplace)
            {
                Query = Query.Replace(kv.Key, kv.Value);
            }

            return Query;

        }

        /// <summary>
        /// Reads Data for all Makelaars for Amsterdam
        /// </summary>
        private void ReadAllAmsterdamData()
        {
            CrawlerData = new FundaRawData();

            long currentPage = 1;


            // double maxAPICalls = CrawlerConstants.MAX_API_CALLS * CrawlerConstants.API_CALLS_PERCENTAGE;
            Stopwatch sw = new Stopwatch();
            sw.Start();

            long now = sw.ElapsedMilliseconds;
            long lastTick = sw.ElapsedMilliseconds;
            while (true)
            {
                now = sw.ElapsedMilliseconds;
                long delta = now - lastTick;
                lastTick = now;

                if (delta < CrawlerConstants.API_THROTTLE_LIMIT_MILLISECS)
                {
                    Thread.Sleep((int)(CrawlerConstants.API_THROTTLE_LIMIT_MILLISECS - delta));
                }
                // Get an URL to query all Amsterdam data for Makelaars, no tuins.
                string query = ConstructURLQuery(Configuration.GetConfiguration().APIKey, DataType, currentPage, false);
                var request = new RestRequest(query, DataFormat.Json);
                var response = restClient.Get(request);

                switch (response.ResponseStatus)
                {
                    case ResponseStatus.Error:
                        switch (response.StatusCode)
                        {

                            case HttpStatusCode.TooManyRequests:
                                continue;
                            default:
                                break;
                        }
                        break;
                    case ResponseStatus.Completed:
                        {
                            if (response.StatusCode == HttpStatusCode.OK)
                            {
                                CrawlerData.ParseJson(response.Content);
                                currentPage = CrawlerData.GetCurrentPage();
                                var maxPages = CrawlerData.GetPageLimit();
                                if (currentPage >= maxPages)
                                {
                                    break;
                                }
                                currentPage++;
                            }
                            break;
                        }

                    default:
                        break;
                }

            }

        }

        /// <summary>
        /// Reads Data for all Makelaars for Amsterdam with Tuin
        /// </summary>
        private void ReadAmsterdamTuinData()
        {
            // Get an URL to query all Amsterdam data for Makelaars, no tuins.
            string Query = ConstructURLQuery(Configuration.GetConfiguration().APIKey, DataType, 1, true);
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