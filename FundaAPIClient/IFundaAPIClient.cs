using System.Collections.Generic;

namespace FundaAPIClient
{
    public interface IFundaAPIClient
    {
        Dictionary<string, long> GetTop10Makelaars();

        Dictionary<string, long> GetTop10MakelaarsWithTuin();
    }

}