using System;
using PagedList;

namespace Models.ViewModels
{
    public class AdminIndexViewModel
    {
        public AdminIndexFilterOptions AdminIndexFilterOptions { get; set; }
        public AdminIndexFiltred AdminIndexFiltred { get; set; }
        public IPagedList<AdminAdvertToShow> Adverts { get; set; }
    }

    public class AdminIndexFiltred
        {
            public int? Page { get; set; }
            public AdTypeAdmin? AdTypeAdmin { get; set; }
            public string FlatCity { get; set; }
            public string LandCity { get; set; }
            public string HouseCity { get; set; }
            public string AllCity { get; set; }
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
                    FlatCity,
                    HouseCity,
                    LandCity,
                    AllCity,
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
