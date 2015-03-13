using Context.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Services.CRUDAdvertServices.DeleteAdvertService.Implementation;
using Services.GenericRepository;

namespace NieruchomosciJG.Tests.ServicesTests
{
    [TestClass]
    public class DeleteAdvertServiceTests
    {
        [TestMethod]
        public void T001_AdvertNotFound_0()
        {
            // Arrange
            var advertRepository = new Mock<IGenericRepository<Advert>>();
            advertRepository.Setup(x => x.Delete(It.IsAny<int>())).Returns((Advert) null);

            // Act
            var deleteAdvertService = new DeleteAdvertService(advertRepository.Object);
            var result = deleteAdvertService.DeleteAdvert(1);

            // Assert
            Assert.AreEqual(result, 0);
        }

        [TestMethod]
        public void T002_AdvertFound_IdIsProper()
        {
            // Arrange
            var advertRepository = new Mock<IGenericRepository<Advert>>();
            advertRepository.Setup(x => x.Delete(It.IsAny<int>())).Returns(new Advert{Id = 1});

            // Act
            var deleteAdvertService = new DeleteAdvertService(advertRepository.Object);
            var result = deleteAdvertService.DeleteAdvert(1);

            // Assert
            Assert.AreEqual(result, 1);
        }
    }
}