using System.Threading.Tasks;
using Microsoft.WindowsAzure.Storage.Blob;

namespace My.AzureStorage.Samples.Lib
{
    public class BlockBlob : IBlockBlob
    {
        private readonly CloudBlockBlob _blockBlob;

        public BlockBlob(CloudBlockBlob blockBlob)
        {
            _blockBlob = blockBlob;
        }
        
        public async Task UploadFromFileAsync(string filePath, string contentType)
        {
            _blockBlob.Properties.ContentType = contentType;
            await _blockBlob.UploadFromFileAsync(filePath);
        }
    }
}
