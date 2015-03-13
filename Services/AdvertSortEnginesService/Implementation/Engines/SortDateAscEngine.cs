using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using Context.Entities;

namespace Services.AdvertSortEnginesService.Implementation.Engines
{
    public interface ISortDateAscEngine : ISortOptionEngine
    {
    }

    [ExcludeFromCodeCoverage]
    public class SortDateAscEngine : ISortDateAscEngine
    {
        public IEnumerable<Advert> Sort(IEnumerable<Advert> adverts)
        {
            return adverts.OrderBy(x => x.CreatedAt);
        }
    }
}