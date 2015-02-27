using System.Collections.Generic;
using Models.ViewModels;

namespace Services.GetAvailableAdvertTypes
{
    public interface IGetAvailableAdvertTypes
    {
        IEnumerable<AdvertTypeViewModel> GetAdvertTypes();
    }
}