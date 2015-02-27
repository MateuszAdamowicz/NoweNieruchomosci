using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using AutoMapper;
using Context.Entities;
using Models.ViewModels;
using Services.GenericRepository;
using System.Drawing;
using Services.ResizeImageService;

namespace Services.PhotoService.Implementation
{
    public class PhotoService : IPhotoService
    {
        private readonly IGenericRepository<Photo> _genericRepository;
        private readonly IResizeImageService _resizeImageService;

        public PhotoService(IGenericRepository<Photo> genericRepository, IResizeImageService resizeImageService)
        {
            _genericRepository = genericRepository;
            _resizeImageService = resizeImageService;
        }

        public List<Photo> AddAdvertPhotos(IEnumerable<HttpPostedFileBase> files)
        {
            return files.Select(SavePhotoAndThumbnail).ToList();
        }

        private Photo SavePhotoAndThumbnail(HttpPostedFileBase file)
        {
            var tempName = FileNameDependingOnBrowser(file);
            var fileName = FileNameWithDateTimePrefix(tempName);
            var path = PathToPhotosDirectory();

            SavePhoto(file, path, fileName);
            SaveThumbnail(path, fileName);

            var photo = AddPhotoToDB(fileName);
            return photo;
        }


        public string FileNameDependingOnBrowser(HttpPostedFileBase file)
        {
            string tempName = HttpContext.Current.Request.Browser.Browser == "InternetExplorer" ? new FileInfo(file.FileName).Name : file.FileName;
            return tempName;
        }

        public IEnumerable<PhotoViewModel> GetPhotosById(IEnumerable<int> ids)
        {
            var photosFromRepository = _genericRepository.GetSet().Where(x => ids.Contains(x.Id));
            var viewModels = Mapper.Map<IEnumerable<PhotoViewModel>>(photosFromRepository);
            return viewModels;
        }

        private Photo AddPhotoToDB(string fileName)
        {
            var photo = new Photo() { Name = fileName, Thumbnail = "min_" + fileName };
            _genericRepository.Add(photo);
            return photo;
        }



        private void SaveThumbnail(string path, string fileName)
        {
            var resized =
                _resizeImageService.ResizeImage(Image.FromFile(path + fileName), 170, 120);

            var minPath = path + "min_" + fileName;

            resized.Save(minPath);
            resized.Dispose();
        }

        private void SavePhoto(HttpPostedFileBase file, string path, string fileName)
        {
            file.SaveAs(path + fileName);
            file.InputStream.Flush();
            file.InputStream.Dispose();
        }

        private string PathToPhotosDirectory()
        {
            var path = HttpContext.Current.Server.MapPath("~/Content/Photos/");
            return path;
        }

        private string FileNameWithDateTimePrefix(string tempName)
        {
            var fileName = String.Format("{0}_{1}", DateTime.Now.ToString("FFFFFFF"), tempName);
            return fileName;
        }


    }
}