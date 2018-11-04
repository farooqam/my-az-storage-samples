using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;

namespace My.AzureStorage.Samples.Lib
{
    public class BlobClientFactory : IBlobClientFactory
    {
        private readonly string _storageConnectionString;

        public BlobClientFactory(string storageConnectionString)
        {
            _storageConnectionString = storageConnectionString;
        }
        public IBlobClient CreateBlobClient()
        {
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(_storageConnectionString);
            CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();
            return new BlobClient(blobClient);
        }
    }
}
