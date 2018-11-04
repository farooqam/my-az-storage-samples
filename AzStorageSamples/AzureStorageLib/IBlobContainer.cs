using System.Threading.Tasks;
using Microsoft.WindowsAzure.Storage.Blob;

namespace My.AzureStorage.Samples.Lib
{
    public interface IBlobContainer
    {
        Task CreateIfNotExistsAsync(BlobRequestOptions options);
        IBlockBlob GetBlockBlobReference(string blobPath);
    }
}
