using System.Linq;
using AutoMapper;
using Context.Entities;
using Models.ViewModels;
using Services.FindPhotosById;
using Services.GenericRepository;
using Services.PhotoService;

namespace Services.CRUDAdvertServices.CreateAdvertService.Implementation
{
    public class CreateAdvertService : ICreateAdvertService
    {
        private readonly IGenericRepository<Advert> _genericRepository;
        private readonly IPhotoService _photoService;
        private readonly IGenericRepository<AdvertType> _advertTypeRepository;
        private readonly IFindPhotosByIdService _findPhotosByIdService;

        public CreateAdvertService(IGenericRepository<Advert> genericRepository,
            IPhotoService photoService,
            IGenericRepository<AdvertType> advertTypeRepository,
            IFindPhotosByIdService findPhotosByIdService )
        {
            _genericRepository = genericRepository;
            _photoService = photoService;
            _advertTypeRepository = advertTypeRepository;
            _findPhotosByIdService = findPhotosByIdService;
        }

        public int CreateAdvert(CreateAdvertViewModel createAdvert)
        {
            var advertToSave = Mapper.Map<Advert>(createAdvert);
            advertToSave.AdvertType = _advertTypeRepository.GetSet().Single(x => x.Mask == createAdvert.AdvertType.Mask);


            var advert = _genericRepository.Add(advertToSave);

            var savedPhotos = _findPhotosByIdService.Find(createAdvert.PhotosToSave);
            _photoService.AddAdvertToPhotos(advert.Id, savedPhotos);

            return advert.Id;
        }
    }
}