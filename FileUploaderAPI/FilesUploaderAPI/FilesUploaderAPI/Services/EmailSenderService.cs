
using FilesUploaderAPI.Models.MailSettings;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using MimeKit;
using Org.BouncyCastle.Asn1.Pkcs;
using System.Net;
using System.Net.Mail;

namespace FilesUploaderAPI.Services
{
    public class EmailSenderService : IEmailSenderService
    {
        private readonly MailSettings _mailSettings;
        public EmailSenderService(IOptions<MailSettings> mailSettingsOptions)
        {
            _mailSettings = mailSettingsOptions.Value;
        }
        public async Task SendEmailAsync(string email)
        {
            var mail = _mailSettings.SenderEmail;
            var pw = _mailSettings.Password;

            var client = new SmtpClient(_mailSettings.Server, _mailSettings.Port)
            {
                EnableSsl = true,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(mail, pw)
                
            };
            await client.SendMailAsync(new MailMessage(from: mail, to: email, "File Upload", "Your file was succesfully uploaded"));
        }
    }
}

