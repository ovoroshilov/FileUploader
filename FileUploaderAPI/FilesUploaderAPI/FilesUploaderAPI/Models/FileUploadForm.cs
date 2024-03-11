namespace FilesUploaderAPI.Models
{
    public class FileUploadForm
    {
        public IFormFile File { get; set; }
        public string Email { get; set; }
    }
}
