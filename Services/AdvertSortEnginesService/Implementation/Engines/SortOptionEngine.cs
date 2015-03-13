using System.Collections.Generic;
using Context.Entities;

namespace Services.AdvertSortEnginesService.Implementation.Engines
{
    public abstract class SortOptionEngine
    {
        public abstract IEnumerable<Advert> Sort(IEnumerable<Advert> adverts);
    }
}