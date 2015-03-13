using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using Models.ViewModels;

namespace Services.DetailedSortService.Implementation.Engines
{
    public interface IDetailedSortToLet : IDetailedSort
    {
    }

    [ExcludeFromCodeCoverage]
    public class DetailedSortToLet : IDetailedSortToLet
    {
        public IEnumerable<AdminAdvertToShow> Sort(IEnumerable<AdminAdvertToShow> adverts)
        {
            return adverts.OrderBy(x => x.ToLet);
        }
    }
}