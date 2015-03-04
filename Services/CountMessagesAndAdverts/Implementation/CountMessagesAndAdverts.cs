using System.Linq;
using Context.Entities;
using Services.GenericRepository;
using Models.ViewModels;

namespace Services.CountMessagesAndAdverts.Implementation
{
    public class CountMessagesAndAdverts : ICountMessagesAndAdverts
    {
        private readonly IGenericRepository<Message> _messageRepository;
        private readonly IGenericRepository<Advert> _advertRepository;

        public CountMessagesAndAdverts(IGenericRepository<Message> messageRepository,
            IGenericRepository<Advert> advertRepository)
        {
            _advertRepository = advertRepository;
            _messageRepository = messageRepository;
        }

        public AdminMenuViewModel Count(AdminMenuViewModel adminMenuViewModel)
        {
            adminMenuViewModel.AdvertsCount = CountAdvert();
            adminMenuViewModel.MessagesCount = CountMessages();

            return adminMenuViewModel;

        } 

        public int CountMessages()
        {
            return _messageRepository.GetSet().Count();
        }

        public int CountAdvert()
        {
            return _advertRepository.GetSet().Count(x => x.Visible);
        }    
    }
}