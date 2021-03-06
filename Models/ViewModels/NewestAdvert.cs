﻿using System;
using System.Diagnostics.CodeAnalysis;
using Context.PartialModels;

namespace Models.ViewModels
{
    [ExcludeFromCodeCoverage]
    public class NewestAdvert
    {
        public int Number { get; set; }
        public string City { get; set; }
        public string Location { get; set; }
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