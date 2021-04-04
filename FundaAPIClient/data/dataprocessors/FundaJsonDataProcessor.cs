

using System.Collections.Generic;
using System.Linq;
using RestSharp.Extensions;

namespace FundaAPIClient
{

    public class FundaJsonDataProcessor : IFundaDataProcessor
    {
        public FundaResults ProcessData(FundaRawData data)
        {

            // Dictionary using makelaarId as a key, for fast key lookup
            Dictionary<int, Makelaar> processedData = new Dictionary<int, Makelaar>();


            // Iterate Json files
            foreach (var json in data.Files)
            {
                // If there are objects in the json data
                if (json.Objects.Count > 0)
                {
                    // let's iterate them
                    foreach (var obj in json.Objects)
                    {
                        // Makelaar has id, is not null and exists.
                        if (obj.MakelaarId.HasValue &&
                        obj.MakelaarNaam != null &&
                        obj.MakelaarNaam.Length > 0)
                        {
                            int id = obj.MakelaarId.Value;
                            // in case that makelaar already exists, incremement count
                            if (processedData.ContainsKey(id))
                            {
                                processedData[id].Count++;
                            }
                            else // else, create a new makelaar and save it
                            {
                                Makelaar m = new Makelaar(id, obj.MakelaarNaam);
                                m.Count++;
                                processedData[id] = m;
                            }
                        }
                    }
                }
            }

            // Create a list with processed data ordered by count
            List<Makelaar> orderedMakelaars = new List<Makelaar>(processedData.Values.OrderByDescending(m => m.Count));
            return new FundaResults()
            {
                Results = orderedMakelaars
            };
        }
    }
}