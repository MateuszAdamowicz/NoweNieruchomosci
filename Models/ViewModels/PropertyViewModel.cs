using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using Models.Resources;

namespace Models.ViewModels
{
    [ExcludeFromCodeCoverage]
    public class PropertyViewModel
    {
        public PropertyViewModel(string name)
        {
            Name = name;
        }

        public PropertyViewModel()
        {
        }
        public string Name { get; set; }

        [MaxLength(40, ErrorMessageResourceType = typeof(StringResource), ErrorMessageResourceName = "MaxLengthProperties")]
        public string Value { get; set; }
    }
}