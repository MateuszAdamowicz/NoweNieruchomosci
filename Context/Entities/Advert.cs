using System.Collections;
using System.Collections.Generic;
using Context.PartialModels;

namespace Context.Entities
{
    public class Advert : BusinessObject
    {
        public string Title { get; set; }
        public bool ToLet { get; set; }
        public int Price { get; set; }
        public int Area { get; set; }
        public string City { get; set; }
        public string Location { get; set; }
        public string Description { get; set; }
        public string Details { get; set; }
        public bool Visible { get; set; }
        public virtual AdvertType AdvertType { get; set; }
        public virtual List<Photo> Photos { get; set; } 
        public virtual List<Property> Properties { get; set; }
        public MapCords MapCords { get; set; }
    }
}