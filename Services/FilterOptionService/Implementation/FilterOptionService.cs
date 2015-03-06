using System.Collections.Generic;
using System.IO;
using System.Linq;
using Context.Entities;
using Models.ViewModels;
using Services.GenericRepository;

namespace Services.FilterOptionService.Implementation
{
    public class FilterOptionService : IFilterOptionService
    {
        private readonly IGenericRepository<Advert> _advertRepository;
        private readonly IGenericRepository<AdvertType> _advertTypeRepository; 

        public FilterOptionService(IGenericRepository<Advert> advertRepository, IGenericRepository<AdvertType> advertTypeRepository )
        {
            _advertRepository = advertRepository;
            _advertTypeRepository = advertTypeRepository;
        }

        public AdminIndexFilterOptions GetOptions()
        {
            var perPage = ItemsPerPage();
            var toLets = ToLets();
            var adType = AdTypes();
            var cities = Cities();

            var adminIndexFilterOptions = new AdminIndexFilterOptions()
            {
                AdTypes = adType,
                ToLet = toLets,
                PerPage = perPage,
                Cities = cities
            };

            return adminIndexFilterOptions;
        }

        public List<SelectOption> Cities()
        {
            var cities =
                _advertRepository.GetSet()
                    .Where(x => x.Visible)
                    .Select(x => x.City)
                    .GroupBy(x => x)
                    .Select(x => x.Key)
                    .Select(city => new SelectOption(city, city))
                    .ToList();

            InsertAllValue(cities);
            
            return cities;
        } 

        public List<SelectOption> AdTypes()
        {
            var adTypes =
                _advertTypeRepository.GetSet()
                    .GroupBy(x => x.Mask, x => x.Name,(key,g) => new SelectOption(g.First(),key.ToString()))
                    .ToList();
            
            InsertAllValue(adTypes);
            
            return adTypes;
        }

        public List<SelectOption> ToLets()
        {
            var toLets = new List<SelectOption>();
            toLets.Add(new SelectOption("Wszystkie", ""));
            toLets.Add(new SelectOption("Sprzedaż", "false"));
            toLets.Add(new SelectOption("Wynajem", "true"));
            return toLets;
        }

        public void InsertAllValue(List<SelectOption> list)
        {
            list.Insert(0, new SelectOption("Wszystkie", ""));
        }

        public List<SelectOption> ItemsPerPage()
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