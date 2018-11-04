using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.Storage.Blob;

namespace My.AzureStorage.Samples.Lib
{
    public class UploadBlobCommand : ICommand
    {
        private readonly IBlobClientFactory _blobClientFactory;
        private readonly string _containerName;

        public UploadBlobCommand(IBlobClientFactory blobClientFactory, string containerName)
        {
            _blobClientFactory = blobClientFactory;
            _containerName = containerName;
        }
        public async Task Run(IDictionary<string, object> parameters)
        {
            IBlobClient client = _blobClientFactory.CreateBlobClient();
            IBlobContainer container = client.GetContainerReference(_containerName);
            await container.CreateIfNotExistsAsync((BlobRequestOptions)parameters["options"]);
            IBlockBlob blob = container.GetBlockBlobReference((string)parameters["blobPath"]);
            await blob.UploadFromFileAsync((string) parameters["filePath"], (string) parameters["contentType"]);
        }
    }
}
