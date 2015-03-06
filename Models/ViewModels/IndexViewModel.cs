using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Web.Routing;
using Context.PartialModels;
using PagedList;

namespace Models.ViewModels
{
    public class IndexViewModel
    {
        public IndexViewModel()
        {
            RouteValues = new RouteValues();
        }

        public SearchOptions SearchOptions { get; set; }
        public IPagedList<SimplifyAdvert> SimplifyAdverts{ get; set; }
        public RouteValues RouteValues { get; set; } 
    }

    public class RouteValues
    {
        public bool? Search { get; set; }
        public int? Page { get; set; }
        public int? PriceFrom { get; set; }
        public int? PriceTo { get; set; }
        public string City { get; set; }
        public bool? ToLet { get; set; }
        public string AdType { get; set; }
        public SortOption? SortOption { get; set; }
    }

    public class SearchOptions
    {
        public List<SelectOption> PropertyTypes { get; set; }
        public List<SelectOption> Cities { get; set; }
        public List<SelectOption> AdvertTypes { get; set; }
        public List<SelectOption> SortOptions { get; set; }
        public int MinPrice { get; set; }
        public int MaxPrice { get; set; }

    }

    public class SimplifyAdvert
    {
        public int Price { get; set; }
        public int Number { get; set; }
        public string Description { get; set; }
        public PhotoViewModel Photo { get; set; }
        public AdvertTypeViewModel AdvertType { get; set; }
        public bool ToLet { get; set; }
        public string Title { get; set; }
        public DateTime CreatedAt { get; set; }
        public int Area { get; set; }
        public string City { get; set; }
        public string Location { get; set; }
        public MapCords MapCords { get; set; }

        public string FormattedPrice
        {
            get
            {
                return Price.ToString("N0");
            }
        }

        public string PricePerMeter
        {
            get
            {
                if (Area != 0)
                {
                    return (Price / (float)Area).ToString("N2");
                }
                return String.Empty;
            }
        }

        public string FullLocation
        {
            get
            {
                if (!String.IsNullOrEmpty(Location))
                    return String.Format("{0} ({1})", City, Location);
                return City;
            }
        }
    }
}