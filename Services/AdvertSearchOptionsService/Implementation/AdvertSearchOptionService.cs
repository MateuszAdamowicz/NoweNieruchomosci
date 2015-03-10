using System.Collections.Generic;
using System.Linq;
using Context.Entities;
using Models.ViewModels;
using Services.GenericRepository;

namespace Services.AdvertSearchOptionsService.Implementation
{
    public class AdvertSearchOptionService : IAdvertSearchOptionService
    {
        private readonly IGenericRepository<Advert> _advertRepo;
        private readonly IGenericRepository<AdvertType> _adTypesRepo;

        public AdvertSearchOptionService(IGenericRepository<Advert> advertRepo, IGenericRepository<AdvertType> adTypesRepo  )
        {
            _advertRepo = advertRepo;
            _adTypesRepo = adTypesRepo;
        }

        public SearchOptions GetOptions()
        {
            var options = new SearchOptions();
            options.AdvertTypes = GetAdvertTypes();
            options.Cities = GetCities();
            options.PropertyTypes = GetPropertyTypes();
            options.SortOptions = GetSortOptions();
            options.MaxPrice = GetMaxPrice();

            return options;
        }

        public int GetMaxPrice()
        {
            int maxPrice = _advertRepo.GetSet().Any() ? _advertRepo.GetSet().Select(x => x.Price).Max() : 2000000;
            return maxPrice;
        }

        public List<SelectOption> GetSortOptions()
        {
            var sortOptions = new List<SelectOption>();
            sortOptions.Add(new SelectOption("Sortuj po: dacie malejąco", "DateDesc"));
            sortOptions.Add(new SelectOption("Sortuj po: dacie rosnąco", "DateAsc"));
            sortOptions.Add(new SelectOption("Sortuj po: miejscowości malejąco", "CityDesc"));
            sortOptions.Add(new SelectOption("Sortuj po: miejscowości rosnąco", "CityAsc"));
            sortOptions.Add(new SelectOption("Sortuj po: cenie malejąco", "PriceDesc"));
            sortOptions.Add(new SelectOption("Sortuj po: cenie rosnąco", "PriceAsc"));
            return sortOptions;
        }

        public List<SelectOption> GetPropertyTypes()
        {
            var adTypes =
                _adTypesRepo.GetSet().Select(x => x.Name).Distinct().Select(x => new SelectOption("Nieruchomość: "+x, x)).ToList();
            return adTypes;
        }

        public List<SelectOption> GetCities()
        {
            var cities = _advertRepo.GetSet().Select(x => x.City).Distinct().Select(x => new SelectOption("Miejscowość: " + x, x)).ToList();
            cities.Insert(0, new SelectOption("Miejscowość: Wszystkie",""));
            return cities;
        }

        public List<SelectOption> GetAdvertTypes()
        {
            var options = new List<SelectOption>();
            options.Add(new SelectOption("Typ oferty: sprzedaż", "false"));
            options.Add(new SelectOption("Typ oferty: wynajem", "true"));

            return options;
        }


    }
}