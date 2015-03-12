using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Web;
using PagedList;

namespace Models.ViewModels
{
    [ExcludeFromCodeCoverage]
    public class AdminIndexViewModel
    {
        public AdminIndexFilterOptions AdminIndexFilterOptions { get; set; }
        public AdminIndexFiltered AdminIndexFiltered { get; set; }
        public IPagedList<AdminAdvertToShow> Adverts { get; set; }
    }
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
                ShowHidden,
                PerPage,
                SortDescAsc,
            };
        }
    }
    [ExcludeFromCodeCoverage]
    public class AdminIndexFilterOptions
    {
        public List<SelectOption> AdTypes { get; set; }
        public List<SelectOption> ToLet { get; set; }
        public List<SelectOption> PerPage { get; set; }
        public List<SelectOption> Cities { get; set; }
    }
    [ExcludeFromCodeCoverage]
    public class AdminAdvertToShow
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string City { get; set; }
        public bool Visible { get; set; }
        public AdvertTypeViewModel AdType { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Number { get; set; }
        public bool Deleted { get; set; }
        public int Price { get; set; }
        public int Area { get; set; }
        public bool ToLet { get; set; }
        public string Thumbnail { get; set; }

        public string GetPhotoPath
        {
            get
            {
                if (File.Exists(HttpContext.Current.Request.MapPath("/Content/Photos/" + Thumbnail)))
                {
                    return String.Format("/Content/Photos/{0}", Thumbnail);
                }
                else
                {
                    return "";
                }
            }
        }
    }


}