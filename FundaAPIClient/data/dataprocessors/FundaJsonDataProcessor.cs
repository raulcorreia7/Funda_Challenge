

using System.Collections.Generic;
using System.Linq;
using RestSharp.Extensions;
using Serilog;

namespace FundaAPIClient
{

    public class FundaJsonDataProcessor : IFundaDataProcessor
    {
        public FundaResults ProcessData(FundaRawData data)
        {

            Log.Debug("FundaJsonDataProcessor :: Starting to Process Data");

            // Dictionary using makelaarId as a key, for fast key lookup
            Dictionary<int, Makelaar> processedData = new Dictionary<int, Makelaar>();


            // Iterate Json files
            Log.Verbose("FundaJsonDataProcessor :: Iterating JSON Files");
            foreach (var json in data.Data)
            {
                // If there are objects in the json data
                Log.Verbose($"FundaJsonDataProcessor :: There are {json.Objects.Count} objects.");
                if (json.Objects.Count > 0)
                {
                    // let's iterate them
                    foreach (var obj in json.Objects)
                    {
                        // Makelaar has id, is not null and exists.
                        Log.Verbose($"Current Makelaar: Name : {obj.MakelaarNaam} Id : {obj.MakelaarId}");
                        if (obj.MakelaarId.HasValue &&
                        obj.MakelaarNaam != null &&
                        obj.MakelaarNaam.Length > 0)
                        {
                            int id = obj.MakelaarId.Value;
                            // in case that makelaar already exists, incremement count
                            if (processedData.ContainsKey(id))
                            {
                                Log.Verbose($"Current Makelaar: Name : {obj.MakelaarNaam} Id : {obj.MakelaarId} Count : {processedData[id].Count}");
                                processedData[id].Count++;
                            }
                            else // else, create a new makelaar and save it
                            {
                                Makelaar m = new Makelaar(id, obj.MakelaarNaam);
                                m.Count++;
                                processedData[id] = m;
                                Log.Verbose($"New Makelaar found! Name : {obj.MakelaarNaam} Id : {obj.MakelaarId} Count : {processedData[id].Count}");
                            }
                        }
                    }
                }
            }

            Log.Debug("FundaJsonDataProcessor :: Finishined Processing Data");
            // Create a list with processed data ordered by count
            List<Makelaar> orderedMakelaars = new List<Makelaar>(processedData.Values.OrderByDescending(m => m.Count));
            return new FundaResults()
            {
                Results = orderedMakelaars
            };
        }
    }
}