namespace My.AzureStorage.Samples.Lib
{
    public interface IBlobClient
    {
        IBlobContainer GetContainerReference(string containerName);
    }
}
