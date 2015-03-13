using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using Context.Entities;

namespace Services.AdvertSortEnginesService.Implementation.Engines
{
    public interface ISortPriceAscEngine : ISortOptionEngine
    {
    }

    [ExcludeFromCodeCoverage]
    public class SortPriceAscEngine : ISortPriceAscEngine
    {
        public IEnumerable<Advert> Sort(IEnumerable<Advert> adverts)
        {
            return adverts.OrderBy(x => x.Price);
        }
    }
}