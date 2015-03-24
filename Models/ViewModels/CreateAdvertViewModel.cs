using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using Context.Entities;
using Context.PartialModels;
using Models.Resources;

namespace Models.ViewModels
{
    [ExcludeFromCodeCoverage]
    public class CreateAdvertViewModel
    {
        [Display(Name = "Tytuł")]
        [Required(ErrorMessageResourceType = typeof(StringResource), ErrorMessageResourceName = "Required")]
        [MaxLength(50, ErrorMessageResourceType = typeof(StringResource), ErrorMessageResourceName = "MaxLength")]
        public string Title { get; set; }

        public bool ToLet { get; set; }


        [Display(Name = "Cena")]
        [Required(ErrorMessageResourceType = typeof(StringResource), ErrorMessageResourceName = "Required")]
        [Range(0, 100000000, ErrorMessageResourceType = typeof(StringResource), ErrorMessageResourceName = "MaxRange")]        
        public int Price { get; set; }

        [Display(Name = "Powierzchnia")]
        [Range(0, 100000000, ErrorMessageResourceType = typeof(StringResource), ErrorMessageResourceName = "MaxRange")]
        public int Area { get; set; }

        [Display(Name = "Miasto")]
        [Required(ErrorMessageResourceType = typeof(StringResource), ErrorMessageResourceName = "Required")]
        [MaxLength(40, ErrorMessageResourceType = typeof(StringResource), ErrorMessageResourceName = "MaxLength")]        
        public string City { get; set; }

        [Display(Name = "Lokalizacja")]
        [MaxLength(40, ErrorMessageResourceType = typeof(StringResource), ErrorMessageResourceName = "MaxLength")]
        public string Location { get; set; }

        [Display(Name = "Opis")]
        [DataType(DataType.MultilineText)]
        [Required(ErrorMessageResourceType = typeof(StringResource), ErrorMessageResourceName = "Required")]
        [MaxLength(1000, ErrorMessageResourceType = typeof(StringResource), ErrorMessageResourceName = "MaxLength")]
        public string Description { get; set; }

        [Display(Name = "Szczegóły")]
        [DataType(DataType.MultilineText)]
        [MaxLength(1000, ErrorMessageResourceType = typeof(StringResource), ErrorMessageResourceName = "MaxLength")]
        public string Details { get; set; }

        public bool Visible { get; set; }
        public AdvertTypeViewModel AdvertType { get; set; }
        public IEnumerable<int> PhotosToSave { get; set; }
        public IEnumerable<PhotoViewModel> SavedPhotos { get; set; }
        public List<PropertyViewModel> Properties { get; set; }
        public MapCordsViewModel MapCords { get; set; }
        public CreateAdvertViewModel()
        {
            PhotosToSave = new List<int>();
            SavedPhotos = new List<PhotoViewModel>();
            Properties = new List<PropertyViewModel>();
        }
    }
}