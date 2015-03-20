using System;
using System.Collections.Generic;
using Context.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Services.CRUDAdvertServices.ReadAdvertService.Implementation;
using Services.GenericRepository;

namespace NieruchomosciJG.Tests.ServicesTests
{
    [TestClass]
    public class ReadAdvertServiceTests
    {
        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void T001_GetAdvertById_AdvertNotFound_ReturnNull()
        {
            // Arrange
            var advertRepo = new Mock<IGenericRepository<Advert>>();
            advertRepo.Setup(x => x.Find(It.IsAny<int>())).Returns((Advert) null);

            // Act
            var readAdvertService = new ReadAdvertService(advertRepo.Object);
            var result = readAdvertService.GetAdvertById(3);
        }

        [TestMethod]
        public void T002_GetCreateAdvertById_AdvertNotFound_ReturnNull()
        {
            // Arrange
            var advertRepo = new Mock<IGenericRepository<Advert>>();
            advertRepo.Setup(x => x.Find(It.IsAny<int>())).Returns((Advert)null);

            // Act
            var readAdvertService = new ReadAdvertService(advertRepo.Object);
            var result = readAdvertService.GetCreateAdvertById(3);
            // Assert
            Assert.IsNull(result);
        }
    }
}