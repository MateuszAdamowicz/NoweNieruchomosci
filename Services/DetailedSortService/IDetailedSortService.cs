using System.Collections.Generic;
using Models.ViewModels;

namespace Services.DetailedSortService
{
    public interface IDetailedSortService
    {
        IEnumerable<AdminAdvertToShow> Sort(AdminSortOption engine, IEnumerable<AdminAdvertToShow> adverts);
    }
}