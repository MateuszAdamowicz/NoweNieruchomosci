using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace Models.ViewModels
{
    [ExcludeFromCodeCoverage]
    public class AdminMenuViewModel
    {
        public IEnumerable<AdvertTypeViewModel> AdvertTypes { get; set; }
        public int MessagesCount { get; set; }
        public int AdvertsCount { get; set; }
    }
}