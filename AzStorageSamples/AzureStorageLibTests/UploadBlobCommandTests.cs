using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.Storage.Blob;
using Moq;
using Xunit;

namespace My.AzureStorage.Samples.Lib.Tests
{
    public class UploadBlobCommandTests
    {
        [Fact]
        public async Task ShouldUploadBlob()
        {
            // Arrange
            string containerName = "container";
            string blobPath = "foo.txt";
            string filePath = "c:\\foo.txt";
            string contentType = "txt";
            BlobRequestOptions options = new BlobRequestOptions();

            Mock<IBlockBlob> blobMock = new Mock<IBlockBlob>();

            Mock<IBlobContainer> containerMock = new Mock<IBlobContainer>();
            containerMock.Setup(m => m.GetBlockBlobReference(blobPath)).Returns(blobMock.Object);
            
            Mock<IBlobClient> clientMock = new Mock<IBlobClient>();
            clientMock.Setup(m => m.GetContainerReference(containerName)).Returns(containerMock.Object);

            Mock<IBlobClientFactory> factoryMock = new Mock<IBlobClientFactory>();
            factoryMock.Setup(m => m.CreateBlobClient()).Returns(clientMock.Object);

            ICommand command = new UploadBlobCommand(factoryMock.Object, containerName);

            IDictionary<string, object> commandParameters = new Dictionary<string, object>
            {
                {"options", options},
                {"blobPath", blobPath},
                {"filePath", filePath},
                {"contentType", contentType }
            };

            // Act
            await command.Run(commandParameters);

            // Assert
            containerMock.Verify(m => m.CreateIfNotExistsAsync(options), Times.Once);
            blobMock.Verify(m => m.UploadFromFileAsync(filePath, contentType), Times.Once);
        }
    }
}
