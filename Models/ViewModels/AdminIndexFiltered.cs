using System;
using System.Diagnostics.CodeAnalysis;

namespace Models.ViewModels
{
    [ExcludeFromCodeCoverage]
    public class AdminIndexFiltered
    {
        public int? Page { get; set; }
        public int? AdType { get; set; }
        public string City { get; set; }
        public int? PriceFrom { get; set; }
        public int? PriceTo { get; set; }
        public int? AreaFrom { get; set; }
        public int? AreaTo { get; set; }
        public DateTime? DateFrom { get; set; }
        public DateTime? DateTo { get; set; }
        public bool? ShowHidden { get; set; }
        public bool? ToLet { get; set; }
        public string Number { get; set; }
        public bool? Filter { get; set; }
        public int? PerPage { get; set; }
        public AdminSortOption? SortOption { get; set; }
        public bool? SortDescAsc { get; set; }
        public object GetValues(int? page)
        {
            return new
            {
                Page = page,
                Number,
                ToLet,
                City,
                PriceFrom,
                PriceTo,
                AreaFrom,
                AreaTo,
                DateFrom,
                DateTo,
                Filter,
                SortOption,
                ShowHidden,
                PerPage,
                SortDescAsc,
            };
        }
    }
}