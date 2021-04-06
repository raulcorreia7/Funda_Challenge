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
        /// API Key for FundaAPI.
        /// Please overwrite the config.json {"APIKey" : "value"}
        /// For testing purposes.
        /// Or override this current value in your test
        /// </summary>
        public string APIKey { get; set; }

        private static readonly string ConfigurationFile = "config.json";

        public Configuration()
        {

        }

        private static Configuration ConfigurationInstance { get; set; }

        public static Configuration LoadConfiguration()
        {
            Log.Debug($"Configuration :: Loading {ConfigurationFile}");
            if (File.Exists(ConfigurationFile))
            {
                var lines = File.ReadAllText(ConfigurationFile);
                ConfigurationInstance = JsonConvert.DeserializeObject<Configuration>(lines);
                Log.Debug($"Configuration ::Loaded {ConfigurationFile} sucessfully!");
            }
            else
            {
                Log.Error("Configuration :: Missing config.json! Creating new without informatio..");
                ConfigurationInstance = new Configuration();
            }
            return ConfigurationInstance;
        }

        public static Configuration GetConfiguration()
        {
            Log.Debug($"Configuration :: Acessing GetConfiguration()");
            if (ConfigurationInstance == null)
            {
                LoadConfiguration();
            }
            return ConfigurationInstance;
        }

        public static void SaveConfiguration()
        {
            Log.Debug($"Configuration :: Saving..");

            var json = JsonConvert.SerializeObject(ConfigurationInstance);
            File.WriteAllText(ConfigurationFile, json);
        }

    }
}