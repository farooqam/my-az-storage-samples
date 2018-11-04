using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using CommandLine;
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
            IBlobClientFactory factory = new BlobClientFactory(options.StorageConnectionString);
            ICommand command = new UploadBlobCommand(factory, options.ContainerName);

            BlobRequestOptions requestOptions = new BlobRequestOptions()
            {
                RetryPolicy = new ExponentialRetry(TimeSpan.FromSeconds(5), 3)
            };

            IDictionary<string, object> commandParameters = new Dictionary<string, object>
            {
                {"options", requestOptions},
                {"blobPath", Path.GetFileName(options.FilePath)},
                {"filePath", options.FilePath},
                {"contentType", options.ContentType }
            };

            await command.Run(commandParameters);
        }
    }
}
