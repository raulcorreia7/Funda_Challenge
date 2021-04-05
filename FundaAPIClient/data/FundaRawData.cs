using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using Serilog;
using Serilog.Events;

namespace FundaAPIClient
{
    /// <summary>
    /// This class is a mere bag holder of rawi nformation to provide easiness of interaction with it.
    /// </summary>
    public class FundaRawData
    {
        public List<FundaJSON> Data = new List<FundaJSON>();

        /// <summary>
        /// Parse JSON File
        /// </summary>
        /// <param name="json"></param>
        public void ParseJson(string json)
        {
            if (Log.IsEnabled(LogEventLevel.Verbose))
            {
                Log.Verbose($"FundaRawData :: Deserializing {json}");
            }
            else if (Log.IsEnabled(LogEventLevel.Debug))
            {
                Log.Debug($"FundaRawData :: Deserializing json");
            }
            FundaJSON fundaJSON = JsonConvert.DeserializeObject<FundaJSON>(json);

            if (fundaJSON != null)
            {
                Log.Debug("FundaRawData :: Saving Deserialized data");
                Data.Add(fundaJSON);
            }

        }

        public int GetCurrentPage()
        {
            Log.Debug("FundaRawData :: Getting current json page");
            if (Data != null && Data.Count > 0)
            {
                int page = Data.Last().Paging.HuidigePagina.Value;
                Log.Debug($"FundaRawData :: Current Page is : {page}");
                return page;
            }
            else
            {
                Log.Error("FundaRawData :: Failed to get current page, no data available.");
                return 0;
            }

        }

        public int GetPageLimit()
        {

            if (Data != null && Data.Count > 0)
            {
                int pageLimit = Data.First().Paging.AantalPaginas.Value;
                Log.Debug($"FundaRawData :: Current Page Limit : {pageLimit}");
                return pageLimit;
            }
            else
            {
                Log.Error("FundaRawData :: Failed to get current page limit, no data available.");
                return 0;
            }
        }
    }
}