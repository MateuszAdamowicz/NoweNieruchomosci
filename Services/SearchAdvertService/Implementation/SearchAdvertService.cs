using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using AutoMapper;
using Context.Entities;
using Models.ViewModels;
using Services.GenericRepository;

namespace Services.SearchAdvertService.Implementation
{
    public class SearchAdvertService : ISearchAdvertService
    {
        private readonly IGenericRepository<Advert> _advertRepo;

        public SearchAdvertService(IGenericRepository<Advert> advertRepo)
        {
            _advertRepo = advertRepo;
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
                switch (sortOption)
                {
                    case SortOption.CityAsc:
                        return adverts.OrderBy(x => x.City);

                    case SortOption.CityDesc:
                        return adverts.OrderByDescending(x => x.City);

                    case SortOption.DateAsc:
                        return adverts.OrderBy(x => x.CreatedAt);

                    case SortOption.DateDesc:
                        return adverts.OrderByDescending(x => x.CreatedAt);

                    case SortOption.PriceAsc:
                        return adverts.OrderBy(x => x.Price);
                    
                    case SortOption.PriceDesc:
                        return adverts.OrderByDescending(x => x.Price);
                }
            }

            return adverts;
        }
    }
}