using System.Collections.Generic;
using System.Linq;
using Context.Entities;
using Models.ViewModels;
using Services.GenericRepository;

namespace Services.FilterAdvertService.Implementation
{
    public class FilterAdvertService : IFilterAdvertService
    {
        private readonly IGenericRepository<Advert> _genericRepository;

        public FilterAdvertService(IGenericRepository<Advert> genericRepository)
        {
            _genericRepository = genericRepository;
        }
        public IEnumerable<AdminAdvertToShow> ActiveAdverts(AdminSortOption? adminSortOption, bool sortDescAsc)
        {
            var adverts = _genericRepository.GetSet().Where(x => x.Visible);
            var advertsToShow = AutoMapper.Mapper.Map<IEnumerable<AdminAdvertToShow>>(adverts);
            
            return advertsToShow;
        }
    }
}