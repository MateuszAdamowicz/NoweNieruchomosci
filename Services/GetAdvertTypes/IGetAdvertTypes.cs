using System.Collections.Generic;
using Models.ViewModels;

namespace Services.GetAdvertTypes
{
    public interface IGetAdvertTypes
    {
        IEnumerable<AdvertTypeViewModel> GetAdvertTypeNameAndMask();
        AdvertTypeViewModel FindAdvertTypeByMask(int Mask);
    }
}