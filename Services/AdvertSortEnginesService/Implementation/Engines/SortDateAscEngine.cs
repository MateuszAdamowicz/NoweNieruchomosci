using System.Collections.Generic;
using System.Linq;
using Context.Entities;

namespace Services.AdvertSortEnginesService.Implementation.Engines
{
    public class SortDateAscEngine : SortOptionEngine
    {
        public override IEnumerable<Advert> Sort(IEnumerable<Advert> adverts)
        {
            return adverts.OrderBy(x => x.CreatedAt);
        }
    }
}