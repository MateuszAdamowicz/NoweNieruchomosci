using System;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using Models.Resources;

namespace Models.ViewModels
{
    [ExcludeFromCodeCoverage]
    public class CreateOfferViewModel
    {
        [Display(Name = "Imię i nazwisko")]
        [Required(ErrorMessageResourceType = typeof(StringResource), ErrorMessageResourceName = "Required")]
        [MaxLength(40, ErrorMessageResourceType = typeof(StringResource), ErrorMessageResourceName = "MaxLength")]
        public string FullName { get; set; }

        [Display(Name = "Email")]
        [Required(ErrorMessageResourceType = typeof(StringResource), ErrorMessageResourceName = "EmailRequired")]
        [DataType(DataType.EmailAddress, ErrorMessageResourceType = typeof(StringResource), ErrorMessageResourceName = "EmailNotValid")]
        [EmailAddress(ErrorMessageResourceType = typeof(StringResource), ErrorMessageResourceName = "EmailNotValid", ErrorMessage = null)]
        [MaxLength(40, ErrorMessageResourceType = typeof(StringResource), ErrorMessageResourceName = "MaxLength")]
        public string Email { get; set; }

        [Display(Name = "Cena")]
        [RegularExpression("[0-9]{0,7}", ErrorMessageResourceType = typeof(StringResource), ErrorMessageResourceName = "PriceNotValid")]
        public string Price { get; set; }

        [Display(Name = "Miasto")]
        [MaxLength(40, ErrorMessageResourceType = typeof(StringResource), ErrorMessageResourceName = "MaxLength")]
        public string City { get; set; }

        [Display(Name = "Lokalizacja")]
        [MaxLength(40, ErrorMessageResourceType = typeof(StringResource), ErrorMessageResourceName = "MaxLength")]                
        public string Location { get; set; }

        [Display(Name = "Opis")]
        [DataType(DataType.MultilineText)]
        [MaxLength(1000, ErrorMessageResourceType = typeof(StringResource), ErrorMessageResourceName = "MaxLength")]               
        public string Description { get; set; }

        [Required(ErrorMessageResourceType = typeof(StringResource), ErrorMessageResourceName = "PhoneNumberRequired")]
        [RegularExpression("[0-9]{6,18}", ErrorMessageResourceType = typeof(StringResource), ErrorMessageResourceName = "PhoneNotValid")]
        public string PhoneNumber { get; set; }
       
        [Display(Name = "Typ nieruchomości")]
        [MaxLength(40, ErrorMessageResourceType = typeof(StringResource), ErrorMessageResourceName = "MaxLength")]             
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