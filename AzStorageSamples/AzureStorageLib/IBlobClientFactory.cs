namespace My.AzureStorage.Samples.Lib
{
    public interface IBlobClientFactory
    {
        IBlobClient CreateBlobClient();
    }
}
