﻿using System;
using System.Collections;
using System.Collections.Generic;
using Context.PartialModels;

namespace Models.ViewModels
{
    public class ShowAdvertViewModel
    {
        public string Title { get; set; }
        public bool ToLet { get; set; }
        public int Price { get; set; }
        public int Area { get; set; }
        public string City { get; set; }
        public string Description { get; set; }
        public string Details { get; set; }
        public bool Visible { get; set; }
        public string AdvertType { get; set; }
        public IEnumerable<PhotoViewModel> Photos { get; set; }
        public IEnumerable<PropertyViewModel> Properties { get; set; }
        public MapCords MapCords { get; set; }
        public DateTime CreatedAt { get; set; }

        public string FormattedPrice
        {
            get
            {
                return Price.ToString("N0");
            }
        }
    }
}