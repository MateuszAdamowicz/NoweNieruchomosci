using System.Net.Mail;
using Models.ViewModels;

namespace Services.EmailServices.SaveEmailService
{
    public interface ISaveEmailService
    {
        void SaveEmail(MailMessage model);
    }
}