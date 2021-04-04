using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace FundaAPIClient
{
    public class FundaData
    {
        public List<FundaJSON> Files = new List<FundaJSON>();

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