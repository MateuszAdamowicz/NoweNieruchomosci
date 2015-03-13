using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using Context.Entities;

namespace Services.AdvertSortEnginesService.Implementation.Engines
{
    public interface ISortPriceDescEngine : ISortOptionEngine
    {
    }

    [ExcludeFromCodeCoverage]
    public class SortPriceDescEngine : ISortPriceDescEngine
    {
        public IEnumerable<Advert> Sort(IEnumerable<Advert> adverts)
        {
            return adverts.OrderByDescending(x => x.Price);
        }
    }
}