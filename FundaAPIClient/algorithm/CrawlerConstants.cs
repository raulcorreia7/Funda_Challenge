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

        public const double API_CALLS_PERCENTAGE = 0.90;

        public const double API_THROTTLE_LIMIT = 60 / (MAX_API_CALLS_PER_MIN * API_CALLS_PERCENTAGE);

        public const int API_THROTTLE_LIMIT_MILLISECS = (int)(60 / (MAX_API_CALLS_PER_MIN * API_CALLS_PERCENTAGE) * 1000);


    }
}