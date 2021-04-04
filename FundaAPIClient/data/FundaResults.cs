using System.Collections.Generic;
using System.Linq;

namespace FundaAPIClient
{
    public class FundaResults
    {
        public List<Makelaar> Results { get; set; }

        public FundaResults()
        {

        }

        public IEnumerable<Makelaar> GetTop10()
        {
            return this.Results.Take(10);
        }
    }

}