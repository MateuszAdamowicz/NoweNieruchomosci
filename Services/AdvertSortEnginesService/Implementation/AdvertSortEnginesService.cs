using System.Collections.Generic;
using Context.Entities;
using Models.ViewModels;
using Services.AdvertSortEnginesService.Implementation.Engines;

namespace Services.AdvertSortEnginesService.Implementation
{
    public class AdvertSortEnginesService : IAdvertSortEnginesService
    {
        private readonly Dictionary<SortOption, ISortOptionEngine> _sortEngines;

        public AdvertSortEnginesService(ISortCityAscEngine sortCityAscEngine, 
            ISortCityDescEngine sortCityDescEngine, 
            ISortDateAscEngine sortDateAscEngine, 
            ISortDateDescEngine sortDateDescEngine,
            ISortPriceAscEngine sortPriceAscEngine,
            ISortPriceDescEngine sortPriceDescEngine)
        {
            _sortEngines = new Dictionary<SortOption, ISortOptionEngine>();
            _sortEngines.Add(SortOption.CityAsc, sortCityAscEngine);
            _sortEngines.Add(SortOption.CityDesc, sortCityDescEngine);

            _sortEngines.Add(SortOption.DateAsc, sortDateAscEngine);
            _sortEngines.Add(SortOption.DateDesc, sortDateDescEngine);

            _sortEngines.Add(SortOption.PriceAsc, sortPriceAscEngine);
            _sortEngines.Add(SortOption.PriceDesc, sortPriceDescEngine);
        }

        public IEnumerable<Advert> Sort(SortOption sortEngine, IEnumerable<Advert> adverts)
        {
            return _sortEngines[sortEngine].Sort(adverts);
        } 
    }
}