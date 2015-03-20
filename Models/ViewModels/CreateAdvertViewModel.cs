using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using Context.Entities;
using Context.PartialModels;

namespace Models.ViewModels
{
    [ExcludeFromCodeCoverage]
    public class CreateAdvertViewModel
    {
        [Required]
        public string Title { get; set; }
        public bool ToLet { get; set; }

        [Required]
        public int Price { get; set; }
        public int Area { get; set; }
        [Required]
        public string City { get; set; }
        public string Location { get; set; }
        [Required]
        public string Description { get; set; }
        public string Details { get; set; }
        public bool Visible { get; set; }
        public AdvertTypeViewModel AdvertType { get; set; }
        public IEnumerable<int> PhotosToSave { get; set; }
        public IEnumerable<PhotoViewModel> SavedPhotos { get; set; }
        public List<PropertyViewModel> Properties { get; set; }
        public MapCords MapCords { get; set; }
        public IEnumerable<int> PhotosToDelete { get; set; }
        public CreateAdvertViewModel()
        {
            PhotosToSave = new List<int>();
            SavedPhotos = new List<PhotoViewModel>();
            Properties = new List<PropertyViewModel>();
            PhotosToDelete = new List<int>();
        }
    }
}