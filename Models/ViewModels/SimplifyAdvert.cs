using System;
using System.Diagnostics.CodeAnalysis;
using Context.PartialModels;

namespace Models.ViewModels
{
    [ExcludeFromCodeCoverage]
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