using System;
using PagedList;

namespace Models.ViewModels
{
    public class AdminIndexViewModel
    {
        public AdminIndexFilterOptions AdminIndexFilterOptions { get; set; }
        public AdminIndexFiltered AdminIndexFiltered { get; set; }
        public IPagedList<AdminAdvertToShow> Adverts { get; set; }
    }
    public class AdminIndexFiltered
    {
        public int? Page { get; set; }
        public string AdTypeAdmin { get; set; }
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
                ShowHidden,
                PerPage,
                SortDescAsc,
            };
        }
    }
}