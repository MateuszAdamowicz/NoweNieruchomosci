using System.Collections.Generic;
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
            Assert.AreEqual(result.Count,0);
        }
    }
}