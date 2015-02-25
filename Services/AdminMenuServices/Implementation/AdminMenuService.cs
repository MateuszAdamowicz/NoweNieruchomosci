using System.Linq;
using Context;
using Context.Entities;
using Services.GenericRepository;
using Models.ViewModels;

namespace Services.AdminMenuServices.Implementation
{
    public class AdminMenuService: IAdminMenuService
    {
        private readonly IGenericRepository _genericRepository;


        public AdminMenuService(IGenericRepository genericRepository)
        {
            _genericRepository = genericRepository;
        }

        public AdminMenuCountsViewModel GetMenuCounters()
        {
            return new AdminMenuCountsViewModel()
            {
                MessagesCount = _genericRepository.GetSet<Message>().Count(),
                OffertsCount = _genericRepository.GetSet<Advert>().Count(x => x.Visible)
            };
        }
    }
}