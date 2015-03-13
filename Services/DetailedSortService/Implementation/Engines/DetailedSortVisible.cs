using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using Models.ViewModels;

namespace Services.DetailedSortService.Implementation.Engines
{
    public interface IDetailedSortVisible : IDetailedSort
    {
    }

    [ExcludeFromCodeCoverage]
    public class DetailedSortVisible : IDetailedSortVisible
    {
        public IEnumerable<AdminAdvertToShow> Sort(IEnumerable<AdminAdvertToShow> adverts)
        {
            return adverts.OrderBy(x => x.Visible);
        }
    }
}