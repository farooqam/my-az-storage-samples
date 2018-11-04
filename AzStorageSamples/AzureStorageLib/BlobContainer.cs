using System.Threading.Tasks;
using Microsoft.WindowsAzure.Storage.Blob;

namespace My.AzureStorage.Samples.Lib
{
    public class BlobContainer : IBlobContainer
    {
        private readonly CloudBlobContainer _container;

        public BlobContainer(CloudBlobContainer container)
        {
            _container = container;
        }

        public async Task CreateIfNotExistsAsync(BlobRequestOptions options)
        {
            await _container.CreateIfNotExistsAsync(options, null);
        }

        public IBlockBlob GetBlockBlobReference(string blobPath)
        {
            CloudBlockBlob blockBlob = _container.GetBlockBlobReference(blobPath);
            return new BlockBlob(blockBlob);
        }
    }
}
