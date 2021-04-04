namespace FundaAPIClient
{
    public interface IFundaDataProcessor
    {
        FundaResults ProcessFundaData(FundaData data);
    }
}