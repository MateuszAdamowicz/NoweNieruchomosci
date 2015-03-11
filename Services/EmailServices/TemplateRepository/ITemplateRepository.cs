using RazorEngine.Templating;

namespace Services.EmailServices.TemplateRepository
{
    public interface ITemplateRepository
    {
        string QuestionAboutAdvert();
        string Question();
        string OfferFromUser();
    }
}