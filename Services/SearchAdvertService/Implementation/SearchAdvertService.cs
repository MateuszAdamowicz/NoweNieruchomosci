using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using AutoMapper;
using Context.Entities;
using Models.ViewModels;
using Services.AdvertSortEnginesService;
using Services.AdvertSortEnginesService.Implementation;
using Services.GenericRepository;

namespace Services.SearchAdvertService.Implementation
{
    public class SearchAdvertService : ISearchAdvertService
    {
        private readonly IGenericRepository<Advert> _advertRepo;
        private readonly IAdvertSortEnginesService _advertSortEnginesService;

        public SearchAdvertService(IGenericRepository<Advert> advertRepo, IAdvertSortEnginesService advertSortEnginesService)
        {
            _advertRepo = advertRepo;
            _advertSortEnginesService = advertSortEnginesService;
        }

        public IEnumerable<SimplifyAdvert> SearchAdverts(int? priceFrom, int? priceTo, string city, bool? toLet,
            string adType, SortOption? sortOption)
        {
            var adverts = _advertRepo.GetSet().Where(x => x.Visible);

            if (priceFrom != null)
                adverts = adverts.Where(x => x.Price >= priceFrom);

            if (priceTo != null)
                adverts = adverts.Where(x => x.Price <= priceTo);

            if (!String.IsNullOrEmpty(city))
                adverts = adverts.Where(x => String.Equals(x.City, city));

            if (toLet != null)
                adverts = adverts.Where(x => x.ToLet == toLet);

            if (!String.IsNullOrEmpty(adType))
                adverts = adverts.Where(x => String.Equals(x.AdvertType.Name, adType));


            adverts = SortAdverts(adverts, sortOption);

            var model = Mapper.Map<List<SimplifyAdvert>>(adverts);

            return model;
        }

        private IEnumerable<Advert> SortAdverts(IEnumerable<Advert> adverts, SortOption? sortOption)
        {
            if (sortOption != null)
            {
                adverts = _advertSortEnginesService.Sort(sortOption.Value, adverts);
            }

            return adverts;
        }
    }
}