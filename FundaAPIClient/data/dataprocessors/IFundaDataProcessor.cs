namespace FundaAPIClient
{
    public interface IFundaDataProcessor
    {
        FundaResults ProcessData(FundaRawData data);
    }
}