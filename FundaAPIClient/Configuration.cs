using System.IO;
using System.Text.Json;
using Newtonsoft.Json;
using RestSharp.Serialization.Json;
using Serilog;
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

        private static Configuration ConfigurationInstance { get; set; }

        public static Configuration LoadConfiguration()
        {
            Log.Debug($"Loading {ConfigurationFile}");
            var lines = File.ReadAllText(ConfigurationFile);
            ConfigurationInstance = JsonConvert.DeserializeObject<Configuration>(lines);
            Log.Debug($"Loaded {ConfigurationFile} sucessfully!");
            return ConfigurationInstance;
        }

        public static Configuration GetConfiguration()
        {
            Log.Debug($"Acessing GetConfiguration()");
            if (ConfigurationInstance == null)
            {
                LoadConfiguration();
            }
            return ConfigurationInstance;
        }


    }
}