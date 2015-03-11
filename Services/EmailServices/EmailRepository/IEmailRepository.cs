using Models.ViewModels;

namespace Services.EmailServices.EmailRepository
{
    public interface IEmailRepository
    {
        void SendAndSaveQuestionAboutAdvert(AdvertContactEmailViewModel model);
    }
}