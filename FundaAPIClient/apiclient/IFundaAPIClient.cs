using System.Collections.Generic;

namespace FundaAPIClient
{
    public interface IFundaAPIClient
    {
        FundaData GetTop10Makelaars();

        FundaData GetTop10MakelaarsWithTuin();
    }

}