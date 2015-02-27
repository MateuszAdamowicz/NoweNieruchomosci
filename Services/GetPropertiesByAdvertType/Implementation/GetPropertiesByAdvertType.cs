using System.Collections.Generic;
using System.Linq;
using Context.Entities;
using Context.PartialModels;
using Models.ViewModels;
using Services.GenericRepository;

namespace Services.GetPropertiesByAdvertType.Implementation
{
    public class GetPropertiesByAdvertType : IGetPropertiesByAdvertType
    {
        private readonly IGenericRepository<PropertyDictionary> _genericRepository;

        public GetPropertiesByAdvertType(IGenericRepository<PropertyDictionary> genericRepository)
        {
            _genericRepository = genericRepository;
        }

        public List<PropertyViewModel> GetProperties(AdvertType advertType)
        {
            var availableProperties = _genericRepository.GetSet().Where(x => (x.Mask & advertType.Mask) > 0);
            var propertyList = availableProperties.Select(prop => new PropertyViewModel(prop.Name)).ToList();

            return propertyList;
        } 
    }
}