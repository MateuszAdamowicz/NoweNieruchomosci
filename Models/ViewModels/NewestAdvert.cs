using System;
using Context.PartialModels;

namespace Models.ViewModels
{
    public class NewestAdvert
    {
        public string Number { get; set; }
        public string City { get; set; }
        public int Price { get; set; }
        public bool ToLet { get; set; }
        public string AdType { get; set; }
        public DateTime CreatedAt { get; set; }
        public PhotoViewModel Picture { get; set; }
        public MapCords MapCords { get; set; }

        public string FormattedPrice
        {
            get
            {
                return Price.ToString("N0");
            }
        }
    }
}