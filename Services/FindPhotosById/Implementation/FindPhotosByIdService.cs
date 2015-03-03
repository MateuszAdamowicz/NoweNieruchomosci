using System.Collections.Generic;
using System.Linq;
using Context.Entities;
using Models.ViewModels;
using Services.GenericRepository;

namespace Services.FindPhotosById.Implementation
{
    public class FindPhotosByIdService : IFindPhotosByIdService
    {
        private readonly IGenericRepository<Photo> _photoRepository;

        public FindPhotosByIdService(IGenericRepository<Photo> photoRepository)
        {
            _photoRepository = photoRepository;
        }

        public IEnumerable<Photo> Find(IEnumerable<int> photosToSave)
        {
            return photosToSave.Select(id => _photoRepository.Find(id)).ToList();
        }
    }
}