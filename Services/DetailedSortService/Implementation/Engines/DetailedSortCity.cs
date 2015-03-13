using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using Models.ViewModels;

namespace Services.DetailedSortService.Implementation.Engines
{
    public interface IDetailedSortCity : IDetailedSort
    {
    }

    [ExcludeFromCodeCoverage]
    public class DetailedSortCity : IDetailedSortCity
    {
        public IEnumerable<AdminAdvertToShow> Sort(IEnumerable<AdminAdvertToShow> adverts)
        {
            return adverts.OrderBy(x => x.City);
        }
    }
}