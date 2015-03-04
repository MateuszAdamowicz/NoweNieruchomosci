using System.Collections;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Context.Entities;
using Models.ViewModels;
using Services.GenericRepository;

namespace Services.NewestAdvertsService.Implementation
{
    public class NewestAdvertsService : INewestAdvertsService
    {
        private readonly IGenericRepository<Advert> _advertsRepo;

        public NewestAdvertsService(IGenericRepository<Advert> advertsRepo )
        {
            _advertsRepo = advertsRepo;
        }

        public IEnumerable<NewestAdvert> GetNewest(int count)
        {
            var adverts = _advertsRepo.GetSet().OrderByDescending(x => x.CreatedAt).Where(x => !x.Visible).Take(count);
            var advertsToShow = Mapper.Map<List<NewestAdvert>>(adverts);
            return advertsToShow;
        }
    }
}