using System.ComponentModel.DataAnnotations;

namespace Models.ViewModels
{
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
        [MaxLength(3)]
        public string Value { get; set; }
    }
}