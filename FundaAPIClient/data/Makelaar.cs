namespace FundaAPIClient
{
    public class Makelaar
    {


        public int Id { get; set; }

        public string Name { get; set; }

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
    }
}