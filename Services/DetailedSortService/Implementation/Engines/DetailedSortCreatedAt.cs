using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using Models.ViewModels;

namespace Services.DetailedSortService.Implementation.Engines
{
    public interface IDetailedSortCreatedAt : IDetailedSort
    {
    }

    [ExcludeFromCodeCoverage]
    public class DetailedSortCreatedAt : IDetailedSortCreatedAt
    {
        public IEnumerable<AdminAdvertToShow> Sort(IEnumerable<AdminAdvertToShow> adverts)
        {
            return adverts.OrderBy(x => x.CreatedAt);
        }
    }
}