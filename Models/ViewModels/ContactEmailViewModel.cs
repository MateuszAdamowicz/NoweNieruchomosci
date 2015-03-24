using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using Models.Resources;

namespace Models.ViewModels
{
    [ExcludeFromCodeCoverage]
    public class ContactEmailViewModel
    {
        [Display(Name = "Imię i Nazwisko")]
        [Required(ErrorMessageResourceType = typeof(StringResource), ErrorMessageResourceName = "Required")]
        [MaxLength(40, ErrorMessageResourceType = typeof(StringResource), ErrorMessageResourceName = "MaxLength")]
        public string FullName { get; set; }

        [Display(Name = "Email")]
        [Required(ErrorMessageResourceType = typeof(StringResource), ErrorMessageResourceName = "EmailRequired")]
        [DataType(DataType.EmailAddress, ErrorMessageResourceType = typeof(StringResource), ErrorMessageResourceName = "EmailNotValid")]
        [EmailAddress(ErrorMessageResourceType = typeof(StringResource), ErrorMessageResourceName = "EmailNotValid", ErrorMessage = null)]
        [MaxLength(40, ErrorMessageResourceType = typeof(StringResource), ErrorMessageResourceName = "MaxLength")]
        public string Email { get; set; }

        [RegularExpression("[0-9]{6,18}", ErrorMessageResourceType = typeof(StringResource), ErrorMessageResourceName = "PhoneNotValid")]
        public string PhoneNumber { get; set; }

        [Display(Name = "Szczegóły")]
        [Required(ErrorMessageResourceType = typeof(StringResource), ErrorMessageResourceName = "Required")]
        [DataType(DataType.MultilineText)]
        [MaxLength(1000, ErrorMessageResourceType = typeof(StringResource), ErrorMessageResourceName = "MaxLength")]        
        public string Body { get; set; }
    }
}