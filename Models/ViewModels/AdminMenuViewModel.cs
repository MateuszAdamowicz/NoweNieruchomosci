using System.Collections;
using System.Collections.Generic;

namespace Models.ViewModels
{
    public class AdminMenuViewModel
    {
        public IEnumerable<AdvertTypeViewModel> AdvertTypes { get; set; }
        public int MessagesCount { get; set; }
        public int AdvertsCount { get; set; }
    }
}