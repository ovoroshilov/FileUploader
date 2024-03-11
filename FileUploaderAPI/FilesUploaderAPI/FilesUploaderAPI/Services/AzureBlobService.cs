using Azure;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using FilesUploaderAPI.Models;

namespace FilesUploaderAPI.Services
{
    public class AzureBlobService : IAzureBlobService
    {
        private readonly BlobServiceClient _blobServiceClient;
        private readonly IConfiguration _configuration;
        public AzureBlobService(IConfiguration configuration)
        {
            _configuration = configuration;
            _blobServiceClient = new BlobServiceClient(_configuration.GetConnectionString("AzureBlobStorage"));


        }
        public async Task<Response<BlobContentInfo>> UploadFileAsync(FileUploadForm fileUpload)
        {
            var _containerClient = _blobServiceClient.GetBlobContainerClient("docs");
            string fileName = fileUpload.File.FileName;

            using (var memoryStream = new MemoryStream())
            {
                await fileUpload.File.CopyToAsync(memoryStream);
                memoryStream.Position = 0;

                var response = await _containerClient.UploadBlobAsync(fileName, memoryStream);

                var blobClient = _containerClient.GetBlobClient(fileName);

                await blobClient.SetMetadataAsync(new Dictionary<string, string>
        {
            { "Email", fileUpload.Email }
        });

                return response;
            }
        }
    }
}
