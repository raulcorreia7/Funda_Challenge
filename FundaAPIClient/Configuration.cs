using System.IO;
using System.Text.Json;
using Newtonsoft.Json;
using RestSharp.Serialization.Json;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace FundaAPIClient
{
    public class Configuration
    {

        /// <summary>
        /// BaseURL for FundaAPI
        /// </summary>
        /// <value></value>
        public string BaseUrl { get; set; }

        /// <summary>
        /// API Key for FundaAPI
        /// </summary>
        /// <value></value>
        public string APIKey { get; set; }

        /// <summary>
        ///  Query
        /// </summary>
        /// <value></value>
        public string Query { get; set; }

        private static readonly string ConfigurationFile = "config.json";

        public Configuration()
        {

        }

        public static Configuration LoadConfiguration()
        {
            var lines = File.ReadAllText(ConfigurationFile);
            return JsonConvert.DeserializeObject<Configuration>(lines);
        }

    }
}