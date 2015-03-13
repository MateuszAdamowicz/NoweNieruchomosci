using System.Collections.Generic;
using Context.Entities;
using Models.ViewModels;
using Services.AdvertSortEnginesService.Implementation.Engines;

namespace Services.AdvertSortEnginesService.Implementation
{
    public class AdvertSortEnginesService : IAdvertSortEnginesService
    {
        private readonly Dictionary<SortOption, SortOptionEngine> _sortEngines;

        public AdvertSortEnginesService()
        {
            _sortEngines = new Dictionary<SortOption, SortOptionEngine>();
            _sortEngines.Add(SortOption.CityAsc, new SortCityAscEngine());
            _sortEngines.Add(SortOption.CityDesc, new SortCityDescEngine());

            _sortEngines.Add(SortOption.DateAsc, new SortDateAscEngine());
            _sortEngines.Add(SortOption.DateDesc, new SortDateDescEngine());

            _sortEngines.Add(SortOption.PriceAsc, new SortPriceAscEngine());
            _sortEngines.Add(SortOption.PriceDesc, new SortPriceDescEngine());
        }

        public IEnumerable<Advert> Sort(SortOption sortEngine, IEnumerable<Advert> adverts)
        {
            return _sortEngines[sortEngine].Sort(adverts);
        } 
    }
}