namespace FundaAPIClient
{
    /// <summary>
    /// POCO class for a Makelaar
    /// </summary>
    public class Makelaar
    {

        /// <summary>
        /// Id of an Makelaar
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Name of an Makelaar
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// How many times it appears in the Funda API Object Data
        /// </summary>
        public int Count { get; set; }


        public Makelaar()
        {
            this.Count = 0;
        }

        public Makelaar(int id, string name)
        {
            this.Id = id;
            this.Name = name;
            this.Count = 0;
        }

        public override string ToString()
        {
            return $"Name: {Name} Id : {Id} Count : {Count}";
        }
    }
}