using System;
using System.IO;
using System.Threading.Tasks;
using CommandLine;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using Microsoft.WindowsAzure.Storage.RetryPolicies;
using My.AzureStorage.Samples.Lib.BlobUploader.CommandLine;

namespace My.AzureStorage.Samples.Lib.BlobUploader
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Options parsedOptions = null;
            Parser.Default.ParseArguments<Options>(args).WithParsed(options => { parsedOptions = options; });
            await Run(parsedOptions);
        }

        static async Task Run(Options options)
        {
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(options.StorageConnectionString);
            CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();
            CloudBlobContainer container = blobClient.GetContainerReference(options.ContainerName);
            BlobRequestOptions requestOptions = new BlobRequestOptions() { RetryPolicy = new ExponentialRetry(TimeSpan.FromSeconds(5), 3) };
            await container.CreateIfNotExistsAsync(requestOptions, null);

            CloudBlockBlob blockBlob = container.GetBlockBlobReference(Path.GetFileName(options.FilePath));
            blockBlob.Properties.ContentType = options.ContentType;
            await blockBlob.UploadFromFileAsync(options.FilePath);
        }
    }
}
