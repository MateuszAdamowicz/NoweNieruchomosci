using Context.Entities;
using Services.GenericRepository;

namespace Services.AdvertMessageService.Implementation
{
    public class AdvertMessageService
    {
        private readonly IGenericRepository<Message> _msgRepository;

        public AdvertMessageService(IGenericRepository<Message> msgRepository)
        {
            _msgRepository = msgRepository;
        }
    }
}