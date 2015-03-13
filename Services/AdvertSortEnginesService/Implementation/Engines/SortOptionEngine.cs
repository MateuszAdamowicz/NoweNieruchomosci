using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Context.Entities;

namespace Services.AdvertSortEnginesService.Implementation.Engines
{
    public interface ISortOptionEngine
    {
        IEnumerable<Advert> Sort(IEnumerable<Advert> adverts);
    }
}