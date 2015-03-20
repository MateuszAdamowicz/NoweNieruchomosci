using System.Collections.Generic;
using System.Web;
using Context.Entities;
using Models.ViewModels;

namespace Services.PhotoService
{
    public interface IPhotoService
    {
        List<Photo> AddAdvertPhotos(IEnumerable<HttpPostedFileBase> files);
        IEnumerable<PhotoViewModel> GetPhotosById(IEnumerable<int> photosToSave);
        IEnumerable<PhotoViewModel> GetPhotosByAdvertId(int id);
        void AddAdvertToPhotos(int advertId, IEnumerable<Photo> photos);
        bool RemovePhotosFromAdvert(int photoToDelete);
    }
}