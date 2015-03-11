using Models.ViewModels;
using RazorEngine;
using RazorEngine.Templating;
using Services.EmailServices.TemplateRepository;

namespace Services.EmailServices.ParseEmailService.Implementation
{
    public class ParseEmailService : IParseEmailService
    {
        private readonly ITemplateRepository _templateRepository;

        public ParseEmailService(ITemplateRepository templateRepository)
        {
            _templateRepository = templateRepository;
        }

        public EmailMessage QuestionAboutAdvert(AdvertContactEmailViewModel model)
        {
            var template = _templateRepository.QuestionAboutAdvert();
            var body = Engine.Razor.RunCompile(template, "QuestionAboutAdvert",
                typeof(AdvertContactEmailViewModel), model);

            var message = new EmailMessage()
            {
                Body = body,
                From = model.Email,
                Subject = "Pytanie dotyczące oferty"
            };

            return message;
        }
    }
}