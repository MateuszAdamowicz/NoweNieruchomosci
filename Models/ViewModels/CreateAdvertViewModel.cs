using System.Collections;
using System.Collections.Generic;
using Context.Entities;
using Context.PartialModels;

namespace Models.ViewModels
{
    public class CreateAdvertViewModel
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
        public AdvertType AdvertType { get; set; }
        public IEnumerable<int> PhotosToSave { get; set; }
        public IEnumerable<PhotoViewModel> SavedPhotos { get; set; }
        public List<PropertyViewModel> Properties { get; set; }
        public MapCords MapCords { get; set; }

        public CreateAdvertViewModel()
        {
            PhotosToSave = new List<int>();
            SavedPhotos = new List<PhotoViewModel>();
            Properties = new List<PropertyViewModel>();
        }
    }
}