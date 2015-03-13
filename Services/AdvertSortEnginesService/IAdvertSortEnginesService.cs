using System.Collections.Generic;
using Context.Entities;
using Models.ViewModels;

namespace Services.AdvertSortEnginesService
{
    public interface IAdvertSortEnginesService
    {
        IEnumerable<Advert> Sort(SortOption sortEngine, IEnumerable<Advert> adverts);
    }
}