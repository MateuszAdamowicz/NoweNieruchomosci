using System.Net.Mail;
using Models.ViewModels;
using Services.ApplicationSettingsService;

namespace Services.EmailServices.SmtpManager.Implementation
{
    public class SmtpManager : ISmtpManager
    {
        private readonly IApplicationSettingsService _applicationSettingsService;

        public SmtpManager(IApplicationSettingsService applicationSettingsService)
        {
            _applicationSettingsService = applicationSettingsService;
        }

        public MailMessage SendEmail(EmailMessage msg)
        {
            var emailFrom = _applicationSettingsService.GetKey("EmailDomain");
            var emailTo = emailFrom;

            var client = new SmtpClient();

            var mail = new MailMessage(emailFrom, emailTo)
            {
                Subject = msg.Subject,
                Body = msg.Body,
                From = new MailAddress(msg.From),
                IsBodyHtml = true
            };

            client.Send(mail);

            return mail;
        }
    }
}