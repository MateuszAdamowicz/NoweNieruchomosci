using System.Collections.Generic;
using System.Linq;
using Context.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Services.CitiesService.Implementation;
using Services.GenericRepository;

namespace NieruchomosciJG.Tests.ServicesTests
{
    [TestClass]
    public class CitiesServiceTests
    {
        [TestMethod]
        public void T001_CitiesWithMaximumNumberOfAdverts_CountLargerThanAdvertsCount_EmptyList()
        {
            // Arrange
            var advertRepo = new Mock<IGenericRepository<Advert>>();
            advertRepo.Setup(x => x.GetSet()).Returns(new List<Advert>());

            // Act
            var citiesService = new CitiesService(advertRepo.Object);
            var result = citiesService.CitiesWithMaximumNumberOfAdverts(10);

            // Assert
            Assert.IsFalse(result.Any());
        }

        [TestMethod]
        public void T002_CitiesWithMaximumNumberOfAdverts_SumOfAdvertsIsProper()
        {
            // Arrange
            var advertRepo = new Mock<IGenericRepository<Advert>>();
            
            const string firstCityName = "city1";
            const string secondCityName = "city2";

            advertRepo.Setup(x => x.GetSet()).Returns(new List<Advert>(){new Advert(){City = firstCityName}, new Advert(){City = firstCityName}, new Advert(){City = secondCityName}});
            
            // Act
            var citiesService = new CitiesService(advertRepo.Object);
            var result = citiesService.CitiesWithMaximumNumberOfAdverts(4).ToList();

            // Assert
            Assert.AreEqual(result.Count(),2);
            Assert.AreEqual(result[0].CityName, firstCityName );
            Assert.AreEqual(result[0].Count, 2 );
            Assert.AreEqual(result[1].Count, 1 );
            Assert.AreEqual(result[1].CityName, secondCityName );
        }
    }
}