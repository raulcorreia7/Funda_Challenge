namespace FundaAPIClient
{
    public interface IFundaDataProcessor
    {
        FundaResults ProcessData(FundaData data);
    }
}