using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Text.Json;
using System.Threading;
using FundaAPIClient;
using RestSharp;
using Serilog;

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

        // Are we querying with tuin?
        private bool withTuin = false;


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
            Log.Debug("CrawlerFundaRestAPI :: Constructing Query");
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
            Log.Debug($"CrawlerFundaRestAPI :: Query : {Query}");
            return Query;

        }

        /// <summary>
        /// Configure Crawler to get Amsterdam with all Data
        /// </summary>
        private void ConfigureAmsterdamData()
        {
            this.withTuin = false;
            CrawlerData = new FundaRawData();

        }

        /// <summary>
        /// Configure Crawler to get Amsterdam with Tuin Data
        /// </summary>
        private void ConfigureAmsterdamTuinData()
        {
            this.withTuin = true;
            CrawlerData = new FundaRawData();
        }

        /// <summary>
        /// Crawl command
        /// </summary>
        /// <returns>Crawler Data</returns>
        public FundaRawData Crawl()
        {
            Log.Debug("CrawlerFundaRestAPI :: Crawling...");
            string apikey = Configuration.GetConfiguration().APIKey;

            long currentPage = 1;
            // Starting stop watch
            Stopwatch sw = new Stopwatch();
            sw.Start();

            // Let's calculate delta time.
            // Point of this is to calculate a rate of requests that is good enough to never trigger TooManyRequests. And if soo, handle it.
            long now = sw.ElapsedMilliseconds;
            long lastTick = sw.ElapsedMilliseconds;

            // Number of retries
            int currentRetryCount = 0;

            while (true)
            {
                // Let's calculate the delta between last request.
                now = sw.ElapsedMilliseconds;
                long delta = now - lastTick;
                lastTick = now;

                // Check if the delta is within throttling limit.
                // If so, report it and sleep a bit.
                if (delta < CrawlerConstants.API_THROTTLE_LIMIT_MILLISECS)
                {

                    int sleepTime = (int)(CrawlerConstants.API_THROTTLE_LIMIT_MILLISECS - delta);
                    Log.Debug($"CrawlerFundaRestAPI :: We hit the throttle limit, sleeping for {sleepTime}ms");
                    Log.Debug($"CrawlerFundaRestAPI :: Throttle Limit : {CrawlerConstants.API_THROTTLE_LIMIT_MILLISECS}ms, Current Delta : {delta}ms");
                    Thread.Sleep(sleepTime);
                }

                // Construct a URL to query.
                string query = ConstructURLQuery(apikey, DataType, currentPage, withTuin);
                Log.Debug($"CrawlerFundaRestAPI :: Building new Request");

                // Construct a Request
                var request = new RestRequest(query, DataFormat.Json);
                Log.Debug($"CrawlerFundaRestAPI :: Executing Request");

                // Execute the Request
                var response = restClient.Execute(request, Method.GET);

                Log.Debug($"CrawlerFundaRestAPI :: We received an Response Status : {response.ResponseStatus}");

                // Decide what to do with the request
                switch (response.ResponseStatus)
                {
                    case ResponseStatus.Error:
                        switch (response.StatusCode)
                        {
                            // If Unauthorized (API Key issues)
                            case HttpStatusCode.Unauthorized:
                                {
                                    Log.Error("CrawlerFundaRestAPI :: We are unauthorized to access the API. Something is wrong. Aborting!");
                                    throw new UnauthorizedAccessException("FundaAPI Unauthorized access.");
                                }
                            // If we are hitting the throttling limit
                            case HttpStatusCode.TooManyRequests:
                                {
                                    Log.Debug("CrawlerFundaRestAPI :: We hit a 429 (Too Many Request Error)");
                                    currentRetryCount++;
                                    Log.Debug($"CrawlerFundaRestAPI :: Retry Count : {currentRetryCount} / {CrawlerConstants.MAX_RETRY_COUNT}");
                                    Log.Debug($"CrawlerFundaRestAPI :: Sleeping {CrawlerConstants.API_TOO_MANY_REQUESTS_SLEEP_TIME}ms");
                                    Thread.Sleep(CrawlerConstants.API_TOO_MANY_REQUESTS_SLEEP_TIME);

                                    if (currentRetryCount > CrawlerConstants.MAX_RETRY_COUNT)
                                    {
                                        goto error;
                                    }

                                    continue;
                                }
                            default:
                                {
                                    currentRetryCount++;

                                    if (currentRetryCount > CrawlerConstants.MAX_RETRY_COUNT)
                                    {
                                        goto error;
                                    }

                                    break;
                                }
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
                                    goto end_gracefully;
                                }
                                currentPage++;
                            }
                            break;
                        }

                    default:
                        break;
                }

            }
        // handle error
        error:
            {
                // none found.
                // generic error.
                throw new InvalidProgramException();
            }


        // end_gracefuly
        end_gracefully:
            sw.Stop();
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
                    this.ConfigureAmsterdamTuinData();
                }
                else if (options[CrawlerConstants.MethodKey] == CrawlerConstants.MethodTop10)
                {
                    this.ConfigureAmsterdamData();
                }
            }
        }
    }
}