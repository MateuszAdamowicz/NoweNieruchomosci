using System.Collections;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using AutoMapper.QueryableExtensions.Impl;
using Context.Entities;
using Models.ViewModels;
using Services.GenericRepository;

namespace Services.MessageSerivce.Implementation
{
    public class MessageService : IMessageService
    {
        private readonly IGenericRepository<Message> _msgRepository;

        public MessageService(IGenericRepository<Message> msgRepository )
        {
            _msgRepository = msgRepository;
        }

        public IEnumerable<MessageViewModel> GetMessages()
        {
            var messages = _msgRepository.GetSet().OrderByDescending(x => x.CreatedAt).ToList();

            var model = Mapper.Map<List<MessageViewModel>>(messages);

            return model;
        }

        public void DeleteMessage(int id)
        {
            _msgRepository.Delete(id);
        }
    }
}