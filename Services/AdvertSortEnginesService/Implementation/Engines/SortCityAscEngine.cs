using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using Context.Entities;

namespace Services.AdvertSortEnginesService.Implementation.Engines
{
    public interface ISortCityAscEngine : ISortOptionEngine
    {
    }

    [ExcludeFromCodeCoverage]
    public class SortCityAscEngine: ISortCityAscEngine
    {
        public IEnumerable<Advert> Sort(IEnumerable<Advert> adverts)
        {
            return adverts.OrderBy(x => x.City);
        }
    }
}