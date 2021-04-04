using System.IO;
using System.Text.Json;
using Newtonsoft.Json;
using RestSharp.Serialization.Json;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace FundaAPIClient
{
    public class Configuration
    {

        public string BaseUrl { get; set; }

        public string APIKey { get; set; }

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