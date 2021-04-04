using System.Collections.Generic;
using System.Linq;
using ConsoleTables;

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


        public string GetTableString()
        {
            var table = new ConsoleTable("Makelaar", "Objects");

            return ConsoleTable
                .From<Makelaar>(this.GetTop10())
                .Configure(o => o.NumberAlignment = Alignment.Right)
                .ToStringAlternative();
        }

        public void PrintTable()
        {
            var table = new ConsoleTable("Makelaar", "Objects");

            ConsoleTable
                .From<Makelaar>(this.GetTop10())
                .Configure(o => o.NumberAlignment = Alignment.Right)
                .Write();
        }
    }

}