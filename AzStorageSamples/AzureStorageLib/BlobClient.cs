using Microsoft.WindowsAzure.Storage.Blob;

namespace My.AzureStorage.Samples.Lib
{
    public class BlobClient : IBlobClient
    {
        private readonly CloudBlobClient _cloudBlobClient;

        public BlobClient(CloudBlobClient cloudBlobClient)
        {
            _cloudBlobClient = cloudBlobClient;
        }

        public IBlobContainer GetContainerReference(string containerName)
        {
            CloudBlobContainer container = _cloudBlobClient.GetContainerReference(containerName);
            return new BlobContainer(container);
        }
    }
}
