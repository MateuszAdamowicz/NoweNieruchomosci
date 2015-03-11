using Models.ViewModels;

namespace Services.EmailServices.ParseEmailService
{
    public interface IParseEmailService
    {
        EmailMessage QuestionAboutAdvert(AdvertContactEmailViewModel model);
        EmailMessage Question(ContactEmailViewModel model);
        EmailMessage OfferFromUser(CreateOfferViewModel model);
    }
}