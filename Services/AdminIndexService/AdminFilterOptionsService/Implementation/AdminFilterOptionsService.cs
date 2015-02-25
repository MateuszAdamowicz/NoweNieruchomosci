using System.Collections.Generic;
using System.Linq;
using Context;
using Context.PartialModels;
using Models.ViewModels;
using Services.GenericRepository;
using Context.Entities;

namespace Services.AdminIndexService.AdminFilterOptionsService.Implementation
{
    public class AdminFilterOptionsService : IAdminFilterOptionsService
    {
        private readonly IGenericRepository _genericRepository;

        public AdminFilterOptionsService(IGenericRepository genericRepository)
        {
            _genericRepository = genericRepository;
        }

        public AdminIndexFilterOptions GetOptions()
        {
            var perPage = ItemsPerPage();

            var offerType = OfferTypes();

            var adType = AdvertTypes();

            var adverts = GetCities<Advert>();
            var flatCities = AdvertTypeCities<Advert>(adverts, AdvertType.Flat);
            var houseCities = AdvertTypeCities<Advert>(adverts, AdvertType.House);
            var landCities = AdvertTypeCities<Advert>(adverts, AdvertType.Land);
            var allCities = AdvertTypeCities<Advert>(adverts);

            InsertAllValue(flatCities, houseCities, landCities, allCities);

            var adminIndexFilterOptions = new AdminIndexFilterOptions()
            {
                AdTypes = adType,
                FlatCities = flatCities,
                HouseCities = houseCities,
                LandCities = landCities,
                AllCities = allCities,
                ToLet = offerType,
                PerPage = perPage
            };

            return adminIndexFilterOptions;
        }

        private IEnumerable<Advert> GetCities<T>() where T : Advert
        {
            var adverts =
                _genericRepository.GetSet<T>()
                    .Where(x => x.Visible);
            return adverts;
        }

        private List<SelectOption> AdvertTypeCities<T>(IEnumerable<Advert> adverts) where T : Advert
        {
                   var cities = adverts
                    .Select(x => x.City)
                    .GroupBy(x => x)
                    .Select(x => x.Key)
                    .Select(city => new SelectOption(city, city))
                    .ToList();
            return cities;
        }

        private List<SelectOption> AdvertTypeCities<T>(IEnumerable<Advert> adverts, AdvertType adType) where T : Advert
        {
            var cities = adverts
                    .Where(x => x.AdvertType == adType)
                    .Select(x => x.City)
                    .GroupBy(x => x)
                    .Select(x => x.Key)
                    .Select(city => new SelectOption(city, city))
                    .ToList();
            return cities;
        }


        private void InsertAllValue(List<SelectOption> flatCities, List<SelectOption> houseCities, List<SelectOption> landCities, List<SelectOption> allCities)
        {
            flatCities.Insert(0, new SelectOption("Wszystkie", ""));
            houseCities.Insert(0, new SelectOption("Wszystkie", ""));
            landCities.Insert(0, new SelectOption("Wszystkie", ""));
            allCities.Insert(0, new SelectOption("Wszystkie", ""));
        }

        private List<SelectOption> AdvertTypes()
        {
            var adType = new List<SelectOption>();
            adType.Add(new SelectOption("Wszystkie", "All"));
            adType.Add(new SelectOption("Mieszkanie", "Flat"));
            adType.Add(new SelectOption("Dom", "House"));
            adType.Add(new SelectOption("Działka", "Land"));
            return adType;
        }

        private List<SelectOption> OfferTypes()
        {
            var offerType = new List<SelectOption>();
            offerType.Add(new SelectOption("Wszystkie", ""));
            offerType.Add(new SelectOption("Sprzedaż", "false"));
            offerType.Add(new SelectOption("Wynajem", "true"));
            return offerType;
        }

        private List<SelectOption> ItemsPerPage()
        {
            var perPage = new List<SelectOption>();
            perPage.Add(new SelectOption("5", "5"));
            perPage.Add(new SelectOption("10", "10"));
            perPage.Add(new SelectOption("20", "20"));
            perPage.Add(new SelectOption("30", "30"));
            return perPage;
        }
    }
}