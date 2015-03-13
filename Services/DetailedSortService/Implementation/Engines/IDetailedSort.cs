using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Models.ViewModels;

namespace Services.DetailedSortService.Implementation.Engines
{
    
    public interface IDetailedSort
    {
        IEnumerable<AdminAdvertToShow> Sort(IEnumerable<AdminAdvertToShow> adverts);
    }
}