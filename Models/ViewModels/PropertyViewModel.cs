using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

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
        public string Value { get; set; }
    }
}