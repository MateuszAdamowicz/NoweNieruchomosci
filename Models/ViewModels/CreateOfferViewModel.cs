using System;

namespace Models.ViewModels
{
    public class CreateOfferViewModel
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Price { get; set; }
        public string City { get; set; }
        public string Location { get; set; }
        public string Description { get; set; }
        public string PhoneNumber { get; set; }
        public string AdvertType { get; set; }

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