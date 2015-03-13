using System.Diagnostics.CodeAnalysis;
namespace Models.ViewModels
{
    [ExcludeFromCodeCoverage]
    public class AdvertContactEmailViewModel:ContactEmailViewModel
    {
        public int AdvertId { get; set; }
    }
}