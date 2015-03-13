using System.Diagnostics.CodeAnalysis;

namespace Models.ViewModels
{
    [ExcludeFromCodeCoverage]
    public class RouteValues
    {
        public bool? Search { get; set; }
        public int? Page { get; set; }
        public int? PriceFrom { get; set; }
        public int? PriceTo { get; set; }
        public string City { get; set; }
        public bool? ToLet { get; set; }
        public string AdType { get; set; }
        public SortOption? SortOption { get; set; }
    }
}