using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using Models.ViewModels;

namespace Services.DetailedSortService.Implementation.Engines
{
    public interface IDetailedSortAdType : IDetailedSort
    {
    }

    [ExcludeFromCodeCoverage]
    public class DetailedSortAdType : IDetailedSortAdType
    {
        public IEnumerable<AdminAdvertToShow> Sort(IEnumerable<AdminAdvertToShow> adverts)
        {
            return adverts.OrderBy(x => x.AdType.Name);
        }
    }
}