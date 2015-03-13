using System.Diagnostics.CodeAnalysis;
using PagedList;

namespace Models.ViewModels
{
    [ExcludeFromCodeCoverage]
    public class AdminIndexViewModel
    {
        public AdminIndexFilterOptions AdminIndexFilterOptions { get; set; }
        public AdminIndexFiltered AdminIndexFiltered { get; set; }
        public IPagedList<AdminAdvertToShow> Adverts { get; set; }
    }
}