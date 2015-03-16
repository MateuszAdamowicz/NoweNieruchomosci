using System.Diagnostics.CodeAnalysis;
using Models.ViewModels;
using RazorEngine;
using RazorEngine.Templating;
using Services.EmailServices.TemplateRepository;

namespace Services.EmailServices.ParseEmailService.Implementation
{
    [ExcludeFromCodeCoverage]
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

        public EmailMessage Question(ContactEmailViewModel model)
        {
            var template = _templateRepository.Question();
            var body = Engine.Razor.RunCompile(template, "Question", typeof (ContactEmailViewModel), model);

            var message = new EmailMessage()
            {
                Body = body,
                From = model.Email,
                Subject = "Pytanie od użytkownika"
            };

            return message;
        }

        public EmailMessage OfferFromUser(CreateOfferViewModel model)
        {
            var template = _templateRepository.OfferFromUser();
            var body = Engine.Razor.RunCompile(template, "OfferFromUser", typeof(CreateOfferViewModel), model);

            var message = new EmailMessage()
            {
                Body = body,
                From = model.Email,
                Subject = "Oferta od użytkownika"
            };

            return message;
        }
    }
}