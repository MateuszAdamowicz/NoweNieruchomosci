using System.Collections.Generic;
using System.Linq;
using Context.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Services.GenericRepository;
using Services.NewestAdvertsService.Implementation;

namespace NieruchomosciJG.Tests.ServicesTests
{
    [TestClass]
    public class NewestAdvertsServiceTest
    {
        [TestMethod]
        public void T001_GetNewest_CountIsZero_EmptyList()
        {
            // Arrange
            var advertRepo = new Mock<IGenericRepository<Advert>>();
            advertRepo.Setup(x => x.GetSet()).Returns(new List<Advert>());

            // Act
            var newestAdvertService = new NewestAdvertsService(advertRepo.Object);
            var result = newestAdvertService.GetNewest(0);

            // Assert
            Assert.IsTrue(!result.Any());
        }

        [TestMethod]
        public void T002_GetNewest_CountIsLargerThanNumberOfAdverts_EmptyList()
        {
            // Arrange
            var advertRepo = new Mock<IGenericRepository<Advert>>();
            advertRepo.Setup(x => x.GetSet()).Returns(new List<Advert>());

            // Act
            var newestAdvertService = new NewestAdvertsService(advertRepo.Object);
            var result = newestAdvertService.GetNewest(5);

            // Assert
            Assert.IsTrue(!result.Any());
        }
    }
}