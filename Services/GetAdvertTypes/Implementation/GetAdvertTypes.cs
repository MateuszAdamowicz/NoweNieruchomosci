using System.Collections.Generic;
using System.Linq;
using AutoMapper.QueryableExtensions.Impl;
using Context.Entities;
using Models.ViewModels;
using Services.GenericRepository;

namespace Services.GetAdvertTypes.Implementation
{
    public class GetAdvertTypes : IGetAdvertTypes
    {
        private readonly IGenericRepository<AdvertType> _genericRepository;

        public GetAdvertTypes(IGenericRepository<AdvertType> genericRepository )
        {
            _genericRepository = genericRepository;
        }

        public IEnumerable<AdvertTypeViewModel> GetAdvertTypeNameAndMask()
        {
            var types = _genericRepository.GetSet().ToList();

            var advertTypes = AutoMapper.Mapper.Map<List<AdvertTypeViewModel>>(types);
            return advertTypes;
        }

        public AdvertTypeViewModel FindAdvertTypeByMask(int mask)
        {
            var advertType = _genericRepository.GetSet().Single(x => x.Mask == mask);

            var model = AutoMapper.Mapper.Map<AdvertTypeViewModel>(advertType);

            return model;

        }
    }
}