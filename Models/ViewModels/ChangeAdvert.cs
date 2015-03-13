using System.Diagnostics.CodeAnalysis;

namespace Models.ViewModels
{
    [ExcludeFromCodeCoverage]
    public class ChangeAdvert
    {
        public bool Deleted { get; set; }
        public bool Visible { get; set; }
        public int Number { get; set; }
    }
}