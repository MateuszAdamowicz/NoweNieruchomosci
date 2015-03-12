using System.Diagnostics.CodeAnalysis;

namespace Models.ViewModels
{
    [ExcludeFromCodeCoverage]
    public class PhotoViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Thumbnail { get; set; } 
    }
}