using FilesUploaderAPI.Models;
using FilesUploaderAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace FilesUploaderAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileUploaderController : Controller
    {
        private readonly IAzureBlobService _azureBlobService;
        private readonly IEmailSenderService _emailSenderService;

        public FileUploaderController(IAzureBlobService azureBlobService, IEmailSenderService emailSenderService)
        {
            _azureBlobService = azureBlobService;
            _emailSenderService = emailSenderService;
        }

        [HttpPost, DisableRequestSizeLimit]
        public async Task<IActionResult> UploadFile(FileUploadForm form)
        {
            await _azureBlobService.UploadFileAsync(form);
            await _emailSenderService.SendEmailAsync(form.Email);
            return Ok();
        }
    }
}
