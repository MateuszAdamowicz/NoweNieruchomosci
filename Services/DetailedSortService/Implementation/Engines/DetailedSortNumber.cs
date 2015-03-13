using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using Models.ViewModels;

namespace Services.DetailedSortService.Implementation.Engines
{
    public interface IDetailedSortNumber : IDetailedSort
    {
    }

    [ExcludeFromCodeCoverage]
    public class DetailedSortNumber : IDetailedSortNumber
    {
        public IEnumerable<AdminAdvertToShow> Sort(IEnumerable<AdminAdvertToShow> adverts)
        {
            return adverts.OrderBy(x => x.Id);
        }
    }
}