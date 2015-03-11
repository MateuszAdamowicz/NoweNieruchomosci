using Models.ViewModels;

namespace Services.EmailServices.ParseEmailService
{
    public interface IParseEmailService
    {
        EmailMessage QuestionAboutAdvert(AdvertContactEmailViewModel model);
    }
}