using System.Linq;
using AutoMapper;
using Context.Entities;
using Models.ViewModels;
using Services.FindPhotosById;
using Services.GenericRepository;
using Services.PhotoService;

namespace Services.CRUDAdvertServices.UpdateAdvertService.Implementation
{
    public class UpdateAdvertService : IUpdateAdvertService
    {
        private readonly IGenericRepository<Advert> _genericRepository;
        private readonly IGenericRepository<AdvertType> _advertTypeRepository;
        private readonly IFindPhotosByIdService _findPhotosByIdService;
        private readonly IPhotoService _photoService;

        public UpdateAdvertService(IGenericRepository<Advert> genericRepository, IGenericRepository<AdvertType> advertTypeRepository, IFindPhotosByIdService findPhotosByIdService, IPhotoService photoService)
        {
            _genericRepository = genericRepository;
            _advertTypeRepository = advertTypeRepository;
            _findPhotosByIdService = findPhotosByIdService;
            _photoService = photoService;
        }

        public int UpdateAdvert(CreateAdvertViewModel updateAdvert, int id)
        {
            var advertToSave = Mapper.Map<Advert>(updateAdvert);
            advertToSave.AdvertType = _advertTypeRepository.GetSet().Single(x => x.Mask == updateAdvert.AdvertType.Mask);
            advertToSave.Id = id;

            var advert = _genericRepository.Update(advertToSave);


            var savedPhotos = _findPhotosByIdService.Find(updateAdvert.PhotosToSave);
            _photoService.AddAdvertToPhotos(advert.Id, savedPhotos);

            return advert.Id;
        }

        public bool ChangeVisibility(int number)
        {
            bool visible = false;
            //parse number when implemented 
            var advert = _genericRepository.Find(number);
            
            if (advert != null)
            {
                advert.Visible = !advert.Visible;
                visible = advert.Visible;
                _genericRepository.Update(advert);
            }
            return visible;
        }
    }
}