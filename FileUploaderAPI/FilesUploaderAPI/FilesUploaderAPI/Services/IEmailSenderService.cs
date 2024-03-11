namespace FilesUploaderAPI.Services
{
    public interface IEmailSenderService
    {
        Task SendEmailAsync(string email);
    }
}
