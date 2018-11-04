using CommandLine;

namespace My.AzureStorage.Samples.Lib.BlobUploader.CommandLine
{
    public class Options
    {
        [Option(Required = true, HelpText = "Azure storage connection string.")]
        public string StorageConnectionString { get; set; }

        [Option(Required = true, HelpText = "Azure storage container name.")]
        public string ContainerName { get; set; }

        [Option('f', Required = true, HelpText = "File to upload.")]
        public string FilePath { get; set; }

        [Option(Required = false, HelpText = "The file's HTTP content-type.")]
        public string ContentType { get; set; }
    }
}
