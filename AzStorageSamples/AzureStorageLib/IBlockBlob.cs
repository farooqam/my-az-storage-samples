using System.Threading.Tasks;

namespace My.AzureStorage.Samples.Lib
{
    public interface IBlockBlob
    {
        Task UploadFromFileAsync(string filePath, string contentType);
    }
}
