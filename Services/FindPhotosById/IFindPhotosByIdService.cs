using System.Collections.Generic;
using Context.Entities;

namespace Services.FindPhotosById
{
    public interface IFindPhotosByIdService
    {
        IEnumerable<Photo> Find(IEnumerable<int> photosToSave);
    }
}