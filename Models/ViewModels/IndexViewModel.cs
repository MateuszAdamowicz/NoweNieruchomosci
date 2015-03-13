using System.Collections;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Web.Routing;
using PagedList;

namespace Models.ViewModels
{
    [ExcludeFromCodeCoverage]
    public class IndexViewModel
    {
        public IndexViewModel()
        {
            RouteValues = new RouteValues();
        }

        public SearchOptions SearchOptions { get; set; }
        public IPagedList<SimplifyAdvert> SimplifyAdverts{ get; set; }
        public RouteValues RouteValues { get; set; } 
    }
}