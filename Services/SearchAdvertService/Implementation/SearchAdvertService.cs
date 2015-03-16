using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
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
    [ExcludeFromCodeCoverage]
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
            var adverts = GetVisibledAdverts();

            adverts = FilterAdvertsByPrice(priceFrom, priceTo, adverts);

            adverts = FilterAdvertsByCity(city, adverts);

            adverts = FilterAdvertsByOfferType(toLet, adverts);

            adverts = FilterAdvertsByAdvertType(adType, adverts);

            adverts = SortAdverts(adverts, sortOption);

            var model = Mapper.Map<List<SimplifyAdvert>>(adverts);

            return model;
        }

        public IEnumerable<Advert> FilterAdvertsByAdvertType(string adType, IEnumerable<Advert> adverts)
        {
            if (!String.IsNullOrEmpty(adType))
                adverts = adverts.Where(x => String.Equals(x.AdvertType.Name, adType));
            return adverts;
        }

        public IEnumerable<Advert> FilterAdvertsByOfferType(bool? toLet, IEnumerable<Advert> adverts)
        {
            if (toLet != null)
                adverts = adverts.Where(x => x.ToLet == toLet);
            return adverts;
        }

        public IEnumerable<Advert> FilterAdvertsByCity(string city, IEnumerable<Advert> adverts)
        {
            if (!String.IsNullOrEmpty(city))
                adverts = adverts.Where(x => String.Equals(x.City, city));
            return adverts;
        }

        public IEnumerable<Advert> FilterAdvertsByPrice(int? priceFrom, int? priceTo, IEnumerable<Advert> adverts)
        {
            if (priceFrom != null)
                adverts = adverts.Where(x => x.Price >= priceFrom);

            if (priceTo != null)
                adverts = adverts.Where(x => x.Price <= priceTo);
            return adverts;
        }

        public IEnumerable<Advert> GetVisibledAdverts()
        {
            var adverts = _advertRepo.GetSet().Where(x => x.Visible);
            return adverts;
        }

        public IEnumerable<Advert> SortAdverts(IEnumerable<Advert> adverts, SortOption? sortOption)
        {
            if (sortOption != null)
            {
                adverts = _advertSortEnginesService.Sort(sortOption.Value, adverts);
            }

            return adverts;
        }
    }
}