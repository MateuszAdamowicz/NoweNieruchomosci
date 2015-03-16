using System.Collections.Generic;
using System.Linq;
using Context.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Services.FilterOptionService.Implementation;
using Services.GenericRepository;

namespace NieruchomosciJG.Tests.ServicesTests
{
    [TestClass]
    public class FilterOptionServiceTests
    {
        [TestMethod]
        public void T001_GetCities_EmptyListOfAdverts_EmptyListOfCities()
        {
            // Arrange
            var advertRepo = new Mock<IGenericRepository<Advert>>();
            var advertTypeRepo = new Mock<IGenericRepository<AdvertType>>();

            advertRepo.Setup(x => x.GetSet()).Returns(new List<Advert>());


            // Act
            var filterOptionService = new FilterOptionService(advertRepo.Object, advertTypeRepo.Object);
            var result = filterOptionService.GetCities();

            // Assert
            Assert.AreEqual(result.Count,1);
            Assert.AreEqual(result.First().Text, "Wszystkie");
        }

        [TestMethod]
        public void T002_GetToLets_ListWithThreeItems()
        {
            // Arrange
            var advertRepo = new Mock<IGenericRepository<Advert>>();
            var adTypesRepo = new Mock<IGenericRepository<AdvertType>>();

            // Act
            var filterOptionService = new FilterOptionService(advertRepo.Object, adTypesRepo.Object);
            var result = filterOptionService.GetToLets();

            // Assert
            Assert.AreEqual(result.Count, 3);
        }

        [TestMethod]
        public void T003_GetItemsPerPage_ListWithFourItems()
        {
            // Arrange
            var advertRepo = new Mock<IGenericRepository<Advert>>();
            var advertTypesRepo = new Mock<IGenericRepository<AdvertType>>();

            // Act
            var filterOptionService = new FilterOptionService(advertRepo.Object, advertTypesRepo.Object);
            var result = filterOptionService.GetItemsPerPage();

            // Assert
            Assert.AreEqual(result.Count, 4);
        }

        [TestMethod]
        public void T004_GetAdTypes_NoTypesFound_ReturnListWithOneOption()
        {
            // Arrange
            var advertRepo = new Mock<IGenericRepository<Advert>>();
            var adTypesRepo = new Mock<IGenericRepository<AdvertType>>();

            adTypesRepo.Setup(x => x.GetSet()).Returns(new List<AdvertType>());

            // Act
            var filterOptionService = new FilterOptionService(advertRepo.Object, adTypesRepo.Object);
            var result = filterOptionService.GetAdTypes();

            // Assert
            Assert.AreEqual(result.Count, 1);
        }
    }
}