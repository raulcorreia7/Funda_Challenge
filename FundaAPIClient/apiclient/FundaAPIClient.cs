using System.Collections.Generic;

namespace FundaAPIClient
{
    public class FundaAPIClient : IFundaAPIClient
    {

        public const int PageSize = 25;
        public const int API_LIMIT_RATE = 100;
        public FundaAPIClient()
        {
        }

        public Dictionary<string, long> GetTop10Makelaars()
        {
            throw new System.NotImplementedException();
        }

        public Dictionary<string, long> GetTop10MakelaarsWithTuin()
        {
            throw new System.NotImplementedException();
        }

        public Dictionary<string, long> Algorithm()
        {

            return null;
        }
    }
}