using System.Net.Mail;
using Context.Entities;
using Models.ViewModels;

namespace Services.EmailServices.SaveEmailService
{
    public interface ISaveEmailService
    {
        void SaveEmail(Message model);
    }
}