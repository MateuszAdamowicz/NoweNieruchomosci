using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using Context.Entities;

namespace Services.AdvertSortEnginesService.Implementation.Engines
{
    public interface ISortDateDescEngine : ISortOptionEngine
    {
    }

    [ExcludeFromCodeCoverage]
    public class SortDateDescEngine : ISortDateDescEngine
    {
        public IEnumerable<Advert> Sort(IEnumerable<Advert> adverts)
        {
            return adverts.OrderByDescending(x => x.CreatedAt);
        }
    }
}