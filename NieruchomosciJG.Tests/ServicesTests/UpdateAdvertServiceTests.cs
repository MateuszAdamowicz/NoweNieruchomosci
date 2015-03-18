using System;
using System.Collections.Generic;
using Context.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Models.ViewModels;
using Moq;
using NieruchomosciJG.App_Start;
using Services.CRUDAdvertServices.UpdateAdvertService.Implementation;
using Services.FindPhotosById;
using Services.GenericRepository;
using Services.PhotoService;

namespace NieruchomosciJG.Tests.ServicesTests
{
    [TestClass]
    public class UpdateAdvertServiceTests
    {

        private Mock<IGenericRepository<Advert>> _advertRepository;
        Mock<IGenericRepository<AdvertType>> _advertTypeRepository;
        Mock<IFindPhotosByIdService> _findPhotosById;
        Mock<IPhotoService> _photoService;

        public UpdateAdvertServiceTests()
        {
            _advertRepository = new Mock<IGenericRepository<Advert>>();
            _advertTypeRepository = new Mock<IGenericRepository<AdvertType>>();
            _findPhotosById = new Mock<IFindPhotosByIdService>();
            _photoService = new Mock<IPhotoService>();

            MapperConfig.Register();
        }

        [TestMethod]
        public void T001_ChangeVisibility_NumberNotFound_False()
        {
            // Arrange
            _advertRepository.Setup(x => x.Find(It.IsAny<int>())).Returns((Advert)null);

            // Act
            var updateAdvertService = new UpdateAdvertService(_advertRepository.Object,
                _advertTypeRepository.Object, _findPhotosById.Object, _photoService.Object);

            var result = updateAdvertService.ChangeVisibility(1);

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void T002_ChangeVisibility_AdvertIsVisible_False()
        {
            // Arrange
            _advertRepository.Setup(x => x.Find(It.IsAny<int>())).Returns(new Advert() {Visible = true});

            // Act
            var updateAdvertService = new UpdateAdvertService(_advertRepository.Object,
    _advertTypeRepository.Object, _findPhotosById.Object, _photoService.Object);
            var result = updateAdvertService.ChangeVisibility(1);
            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void T003_ChangeVisibility_AdvertIsHidden_True()
        {
            // Arrange
            _advertRepository.Setup(x => x.Find(It.IsAny<int>())).Returns(new Advert() { Visible = false });

            // Act
            var updateAdvertService = new UpdateAdvertService(_advertRepository.Object,
_advertTypeRepository.Object, _findPhotosById.Object, _photoService.Object);
            var result = updateAdvertService.ChangeVisibility(1);

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void T004_UpdateAdvert_AdvertTypeNotFound_Exception()
        {
            // Arrange
            _advertTypeRepository.Setup(x => x.GetSet()).Returns(new List<AdvertType>());

            // Act
            var updateAdvertService = new UpdateAdvertService(_advertRepository.Object,
_advertTypeRepository.Object, _findPhotosById.Object, _photoService.Object);

            var result = updateAdvertService.UpdateAdvert(new CreateAdvertViewModel(), 1);
            // Assert
        }

        [TestMethod]
        public void T005_UpdateAdvert_GeneralTest()
        {   
            // Arrange
            _advertTypeRepository.Setup(x => x.GetSet()).Returns(new List<AdvertType>(){new AdvertType(){Mask = 1}});
            _advertRepository.Setup(x => x.Update(It.IsAny<Advert>())).Returns(new Advert(){Id = 1});
            _findPhotosById.Setup(x => x.Find(It.IsAny<IEnumerable<int>>())).Returns(new List<Photo>());
            _photoService.Setup(x => x.AddAdvertToPhotos(It.IsAny<Advert>(),It.IsAny<IEnumerable<Photo>>()));

            // Act
            var updateAdvertService = new UpdateAdvertService(_advertRepository.Object,
_advertTypeRepository.Object, _findPhotosById.Object, _photoService.Object);
            var result =
    updateAdvertService.UpdateAdvert(new CreateAdvertViewModel()
    {
        AdvertType = new AdvertTypeViewModel() { Mask = 1 }
    }, 1);
            // Assert
            Assert.AreEqual(result, 1);
        }
    }
}