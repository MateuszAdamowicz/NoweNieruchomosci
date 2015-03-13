using System.Collections.Generic;
using System.Linq;
using Context.Entities;

namespace Services.AdvertSortEnginesService.Implementation.Engines
{
    public class SortCityDescEngine : SortOptionEngine
    {
        public override IEnumerable<Advert> Sort(IEnumerable<Advert> adverts)
        {
            return adverts.OrderByDescending(x => x.City);
        }
    }
}