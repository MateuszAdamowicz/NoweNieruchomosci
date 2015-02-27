using AutoMapper;
using Context.Entities;
using Models.ViewModels;
using Services.GenericRepository;

namespace Services.CRUD.AdvertServices.CreateAdvertService.Implementation
{
    public class CreateAdvertService
    {
        private readonly IGenericRepository<Advert> _genericRepository;

        public CreateAdvertService(IGenericRepository<Advert> genericRepository)
        {
            _genericRepository = genericRepository;
        }

        public int CreateAdvert(CreateAdvertViewModel createAdvert)
        {
            var advert = Mapper.Map<Advert>(createAdvert);

            var savedAdvert = _genericRepository.Add(advert);

            return savedAdvert.Id;
        }
    }
}