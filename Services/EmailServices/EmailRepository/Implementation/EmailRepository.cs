using AutoMapper;
using Context.Entities;
using Models.ViewModels;
using Services.EmailServices.ParseEmailService;
using Services.EmailServices.SaveEmailService;
using Services.EmailServices.SmtpManager;

namespace Services.EmailServices.EmailRepository.Implementation
{
    public class EmailRepository : IEmailRepository
    {
        private readonly IParseEmailService _parseEmailService;
        private readonly ISaveEmailService _saveEmailService;
        private readonly ISmtpManager _smtpManager;

        public EmailRepository(IParseEmailService parseEmailService, ISaveEmailService saveEmailService, ISmtpManager smtpManager)
        {
            _parseEmailService = parseEmailService;
            _saveEmailService = saveEmailService;
            _smtpManager = smtpManager;
        }

        public void SendAndSaveQuestionAboutAdvert(AdvertContactEmailViewModel model)
        {
            var msg = _parseEmailService.QuestionAboutAdvert(model);
            var email = _smtpManager.SendEmail(msg);

            var message = Mapper.Map<Message>(model);
            message.Body = email.Body;

            _saveEmailService.SaveEmail(message);
        }

        public void SendAndSaveQuestion(ContactEmailViewModel model)
        {
            var msg = _parseEmailService.Question(model);
            var email = _smtpManager.SendEmail(msg);

            var message = Mapper.Map<Message>(model);
            message.Body = email.Body;

            _saveEmailService.SaveEmail(message);
        }

        public void SendAndSaveOfferFromUser(CreateOfferViewModel model)
        {
            var msg = _parseEmailService.OfferFromUser(model);
            var email = _smtpManager.SendEmail(msg);

            var message = Mapper.Map<Message>(model);
            message.Body = email.Body;

            _saveEmailService.SaveEmail(message);
        }
    }
}