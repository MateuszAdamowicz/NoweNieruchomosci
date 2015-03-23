using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using AutoMapper;
using Models.ViewModels;
using Services.PhotoService;

namespace NieruchomosciJG.Controllers
{
    public class PhotoController : ApiController
    {
        private readonly IPhotoService _photoService;

        public PhotoController(IPhotoService photoService)
        {
            _photoService = photoService;
        }

        [HttpPost]
        public List<UploadedPhoto> AddPhoto()
        {
            var encodedFiles = HttpContext.Current.Request.Files;
            var files = new List<HttpPostedFileBase>();
            if (encodedFiles != null && encodedFiles.Count > 0)
            {
                for (int i = 0; i < encodedFiles.Count; i++)
                {
                    var image = new HttpPostedFileWrapper(encodedFiles.Get(i));
                    files.Add(image);
                }
                var photos = _photoService.AddAdvertPhotos(files);

                return Mapper.Map<List<UploadedPhoto>>(photos);
            }
            return new List<UploadedPhoto>() { null };
        }

        [HttpPost]
        public bool RemovePhoto([FromBody]int id)
        {        
           var result = _photoService.RemovePhotosFromAdvert(id);

            return result;
        } 
    }
}
