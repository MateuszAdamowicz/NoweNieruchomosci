using System.Collections.Generic;
using Context.Entities;
using Context.PartialModels;
using Models.ViewModels;

namespace Services.GetPropertiesByAdvertType
{
    public interface IGetPropertiesByAdvertType
    {
        List<PropertyViewModel> GetProperties(AdvertTypeViewModel advertType);
    }
}