using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using Serilog;
using Serilog.Events;

namespace FundaAPIClient
{
    /// <summary>
    /// This class is a mere bag holder of raw funda information.
    /// </summary>
    public class FundaRawData
    {
        public List<FundaJSON> Data = new List<FundaJSON>();

        /// <summary>
        /// Parse a json string and save it.
        /// </summary>
        /// <param name="json">json in raw string format.</param>
        public void ParseJson(string json)
        {
            if (json != null && json.Length > 0)
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
        }

        /// <summary>
        /// Returns the current page (last object)
        /// </summary>
        /// <returns>current page</returns>
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

        /// <summary>
        /// Get the page limit from data
        /// </summary>
        /// <returns>page limit</returns>
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

        /// <summary>
        /// Returns if the data was able to be completly pulled from external sources.
        /// </summary>
        /// <returns>true or false</returns>
        public bool IsDataComplete()
        {
            return GetCurrentPage() == GetPageLimit();
        }
    }
}