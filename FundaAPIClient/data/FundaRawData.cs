using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace FundaAPIClient
{
    /// <summary>
    /// This class is a mere bag holder of rawi nformation to provide easiness of interaction with it.
    /// </summary>
    public class FundaRawData
    {
        public List<FundaJSON> Files = new List<FundaJSON>();

        /// <summary>
        /// Parse JSON File
        /// </summary>
        /// <param name="json"></param>
        public void ParseJson(string json)
        {
            FundaJSON fundaJSON = JsonConvert.DeserializeObject<FundaJSON>(json);

            if (fundaJSON != null)
            {
                Files.Add(fundaJSON);
            }

        }
    }
}