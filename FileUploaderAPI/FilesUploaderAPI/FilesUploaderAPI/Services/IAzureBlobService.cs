using Azure;
using Azure.Storage.Blobs.Models;
using FilesUploaderAPI.Models;

namespace FilesUploaderAPI.Services
{
    public interface IAzureBlobService
    {
        Task<Response<BlobContentInfo>> UploadFileAsync(FileUploadForm fileUpload);
    }
}
