using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Serilog;
using Serilog.Events;

namespace FundaAPIClient
{
    /// <summary>
    /// This class is a mere bag holder of raw funda information.
    /// </summary>
    public class FundaRawData
    {
        /*
            We are using memory to save all json files.
            For sake of alternatives we could use something else to save on memory like.
            A remote database, a localdatabase or trim the json files to the bare minimum.

            Architecture alternative:
            Reengineer architecture to be multi thread safe and provide parallel processing.
        */
        public List<FundaJSON> Data = new List<FundaJSON>();

        private int currentPage = 0;
        private int pageLimit = 0;

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
                    Log.Verbose($"FundaRawData :: Deserializing {FormatJson(json)}");
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

                    currentPage = Data.Last().Paging.HuidigePagina.Value;
                    pageLimit = Data.Last().Paging.AantalPaginas.Value;

                    if (currentPage % 5 == 0 || currentPage == pageLimit)
                    {
                        Log.Information($"FundaRawData :: Processed {GetCurrentPage()} of {GetPageLimit()} pages.");
                    }
                }
            }
        }

        /// <summary>
        /// Returns the current page (last object)
        /// </summary>
        /// <returns>current page</returns>
        public int GetCurrentPage()
        {
            Log.Debug($"FundaRawData :: Current Page is : {currentPage}");
            return currentPage;
        }

        /// <summary>
        /// Get the page limit from data
        /// </summary>
        /// <returns>page limit</returns>
        public int GetPageLimit()
        {
            Log.Debug($"FundaRawData :: Current Page Limit : {pageLimit}");
            return pageLimit;
        }

        /// <summary>
        /// Returns if the data was able to be completly pulled from external sources.
        /// </summary>
        /// <returns>true or false</returns>
        public bool IsDataComplete()
        {
            return currentPage == pageLimit;
        }

        /// <summary>
        /// Stack OverFlow C# fast JSON Pretty Print without Deserialization
        /// Source : https://stackoverflow.com/a/57100143
        /// </summary>
        /// <param name="json"></param>
        /// <param name="indent"></param>
        /// <returns></returns>
        private static string FormatJson(string json, string indent = "  ")
        {
            var indentation = 0;
            var quoteCount = 0;
            var escapeCount = 0;

            var result =
                from ch in json ?? string.Empty
                let escaped = (ch == '\\' ? escapeCount++ : escapeCount > 0 ? escapeCount-- : escapeCount) > 0
                let quotes = ch == '"' && !escaped ? quoteCount++ : quoteCount
                let unquoted = quotes % 2 == 0
                let colon = ch == ':' && unquoted ? ": " : null
                let nospace = char.IsWhiteSpace(ch) && unquoted ? string.Empty : null
                let lineBreak = ch == ',' && unquoted ? ch + Environment.NewLine + string.Concat(Enumerable.Repeat(indent, indentation)) : null
                let openChar = (ch == '{' || ch == '[') && unquoted ? ch + Environment.NewLine + string.Concat(Enumerable.Repeat(indent, ++indentation)) : ch.ToString()
                let closeChar = (ch == '}' || ch == ']') && unquoted ? Environment.NewLine + string.Concat(Enumerable.Repeat(indent, --indentation)) + ch : ch.ToString()
                select colon ?? nospace ?? lineBreak ?? (
                    openChar.Length > 1 ? openChar : closeChar
                );

            return string.Concat(result);
        }
    }
}