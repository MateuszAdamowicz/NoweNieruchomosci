using System.Net.Mail;
using Models.ViewModels;

namespace Services.EmailServices.SmtpManager
{
    public interface ISmtpManager
    {
        MailMessage SendEmail(EmailMessage msg);
    }
}