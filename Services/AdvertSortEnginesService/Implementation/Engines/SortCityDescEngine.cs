using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using Context.Entities;

namespace Services.AdvertSortEnginesService.Implementation.Engines
{
    public interface ISortCityDescEngine : ISortOptionEngine
    {
    }

    [ExcludeFromCodeCoverage]
    public class SortCityDescEngine : ISortCityDescEngine
    {
        public IEnumerable<Advert> Sort(IEnumerable<Advert> adverts)
        {
            return adverts.OrderByDescending(x => x.City);
        }
    }
}