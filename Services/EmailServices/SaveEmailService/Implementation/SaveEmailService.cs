using System.Diagnostics.CodeAnalysis;
using System.Net.Mail;
using AutoMapper;
using Context.Entities;
using Models.ViewModels;
using Services.GenericRepository;

namespace Services.EmailServices.SaveEmailService.Implementation
{
    [ExcludeFromCodeCoverage]
    public class SaveEmailService: ISaveEmailService
    {
        private readonly IGenericRepository<Message> _msgRepository;

        public SaveEmailService(IGenericRepository<Message> msgRepository)
        {
            _msgRepository = msgRepository;
        }

        public void SaveEmail(Message model)
        {
            _msgRepository.Add(model);
        }
    }
}