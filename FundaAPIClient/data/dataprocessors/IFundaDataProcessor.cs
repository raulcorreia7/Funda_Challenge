namespace FundaAPIClient
{
    /// <summary>
    /// Minimal interface for a Data Processor for Funda Data type comsumption
    /// </summary>
    public interface IFundaDataProcessor
    {
        /// <summary>
        /// Process Raw Funda Data
        /// </summary>
        /// <param name="data">Raw Funda Data to be processed</param>
        /// <returns>Data in a processed format</returns>
        FundaResults ProcessData(FundaRawData data);
    }
}