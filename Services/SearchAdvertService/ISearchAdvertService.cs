using System.Collections.Generic;
using Models.ViewModels;

namespace Services.SearchAdvertService
{
    public interface ISearchAdvertService
    {
        IEnumerable<SimplifyAdvert> SearchAdverts(int? priceFrom, int? priceTo, string city, bool? toLet,
            string adType, SortOption? sortOption);
    }
}