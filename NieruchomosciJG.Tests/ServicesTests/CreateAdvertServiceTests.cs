using System;
using System.Collections.Generic;
using Context.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Models.ViewModels;
using Moq;
using NieruchomosciJG.App_Start;
using Services.CRUDAdvertServices.CreateAdvertService.Implementation;
using Services.CRUDAdvertServices.UpdateAdvertService.Implementation;
using Services.FindPhotosById;
using Services.GenericRepository;
using Services.PhotoService;

namespace NieruchomosciJG.Tests.ServicesTests
{
    [TestClass]
    public class CreateAdvertServiceTests
    {
        private Mock<IGenericRepository<Advert>> _advertRepository;
        private Mock<IGenericRepository<AdvertType>> _advertTypeRepository;
        private Mock<IPhotoService> _photoService;
        private Mock<IFindPhotosByIdService> _findPhotosById;

        public CreateAdvertServiceTests()
        {
            _advertRepository = new Mock<IGenericRepository<Advert>>();
            _advertTypeRepository = new Mock<IGenericRepository<AdvertType>>();
            _findPhotosById = new Mock<IFindPhotosByIdService>();
            _photoService = new Mock<IPhotoService>();

            MapperConfig.Register();
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void T001_UpdateAdvert_AdvertTypeNotFound_Exception()
        {
            // Arrange
            _advertTypeRepository.Setup(x => x.GetSet()).Returns(new List<AdvertType>());

            // Act
            var createAdvertService = new CreateAdvertService(_advertRepository.Object,
_photoService.Object, _advertTypeRepository.Object, _findPhotosById.Object);

            var result = createAdvertService.CreateAdvert(new CreateAdvertViewModel());
            // Assert
        }

        [TestMethod]
        public void T002_UpdateAdvert_GeneralTest()
        {
            // Arrange
            _advertTypeRepository.Setup(x => x.GetSet()).Returns(new List<AdvertType>() { new AdvertType() { Mask = 1 } });
            _advertRepository.Setup(x => x.Add(It.IsAny<Advert>())).Returns(new Advert() { Id = 1 });
            _findPhotosById.Setup(x => x.Find(It.IsAny<IEnumerable<int>>())).Returns(new List<Photo>());
            _photoService.Setup(x => x.AddAdvertToPhotos(It.IsAny<int>(), It.IsAny<IEnumerable<Photo>>()));

            // Act
            var createAdvertService = new CreateAdvertService(_advertRepository.Object,
_photoService.Object, _advertTypeRepository.Object, _findPhotosById.Object);
            var result =
    createAdvertService.CreateAdvert(new CreateAdvertViewModel()
    {
        AdvertType = new AdvertTypeViewModel() { Mask = 1 }
    });
            // Assert
            Assert.AreEqual(result, 1);
        }
    }
}