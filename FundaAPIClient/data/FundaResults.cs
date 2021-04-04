using System.Collections.Generic;
using System.Linq;
using ConsoleTables;

namespace FundaAPIClient
{
    /// <summary>
    /// Class with post-processed information for the challenge.
    /// </summary>
    public class FundaResults
    {
        /// <summary>
        /// List of Makelaars
        /// </summary>
        public List<Makelaar> Results { get; set; }

        /// <summary>
        /// Gets the Top10 Makelaars.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Makelaar> GetTop10()
        {
            return this.Results.Take(10);
        }

        /// <summary>
        ///  Gets the String representing the Top10 Table, for testing purposes.
        /// </summary>
        /// <returns>String representing the Table</returns>
        public string GetTableString()
        {
            var table = new ConsoleTable("Makelaar", "Objects");

            return ConsoleTable
                .From<Makelaar>(this.GetTop10())
                .Configure(o => o.NumberAlignment = Alignment.Right)
                .ToStringAlternative();
        }

        /// <summary>
        ///  Prints the Top10 Table.
        /// </summary>
        /// <returns>String representing the Table</returns>
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