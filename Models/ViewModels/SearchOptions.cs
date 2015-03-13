using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace Models.ViewModels
{
    [ExcludeFromCodeCoverage]
    public class SearchOptions
    {
        public List<SelectOption> PropertyTypes { get; set; }
        public List<SelectOption> Cities { get; set; }
        public List<SelectOption> AdvertTypes { get; set; }
        public List<SelectOption> SortOptions { get; set; }
        public int MinPrice { get; set; }
        public int MaxPrice { get; set; }

    }
}