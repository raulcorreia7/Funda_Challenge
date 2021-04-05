namespace FundaAPIClient
{
    /// <summary>
    /// This class contains Constants common to the Crawlers
    /// </summary>
    public static class CrawlerConstants
    {

        /// <summary>
        ///  Method key constant
        /// </summary>
        public const string MethodKey = "Method";

        /// <summary>
        /// Method signaling Top10 Function to be used
        /// </summary>
        public const string MethodTop10 = "Top10";

        /// <summary>
        /// Method signaling Top10WithTuin Function to be used
        /// </summary>
        public const string MethodTop10WithTuin = "Top10WithTuin";

        /// <summary>
        /// String with API_URL friendly for Query construction;
        /// </summary>
        public const string API_URL = "http://partnerapi.funda.nl/feeds/Aanbod.svc/[datatype]/[key]/?type=koop&zo=/amsterdam/[tuin]&page=[pageindex]&pagesize=25";

        /// <summary>
        /// Number of API Calls until it starts throwing 429 error
        /// </summary>
        public const int MAX_API_CALLS_PER_MIN = 100;

        /// <summary>
        /// Percentage of max API calls to effectively use.
        /// </summary>
        public const double API_CALLS_PERCENTAGE = 0.95;

        /// <summary>
        /// Calculates the number of API calls per second to not trigger Too many request errors (in seconds)
        /// </summary>
        public const double API_THROTTLE_LIMIT = (MAX_API_CALLS_PER_MIN * API_CALLS_PERCENTAGE) / 60;

        /// <summary>
        ///  Calculate the Delta (in milliseconds) between each API call.
        /// </summary>
        public const int API_THROTTLE_LIMIT_MILLISECS = (int)(API_THROTTLE_LIMIT * 1000);

        /// <summary>
        /// Max Retry count.
        /// </summary>
        public const int MAX_RETRY_COUNT = 10;

        /// <summary>
        /// Sleep time in case of trigger one Too many request error (in milliseconds)
        /// </summary>
        public const int API_TOO_MANY_REQUESTS_SLEEP_TIME = 2000;
    }
}