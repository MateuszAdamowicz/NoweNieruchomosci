using System;
using System.Collections.Generic;
using Context.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Models.ViewModels;
using Moq;
using Moq.Language.Flow;
using Services.AdvertSearchOptionsService.Implementation;
using Services.GenericRepository;

namespace NieruchomosciJG.Tests.ServicesTests
{
    [TestClass]
    public class AdvertSearchOptionServiceTest
    {
        [TestMethod]
        public void T001_GetSortOptons_SortOptionsHasAllKeys()
        {
            // Arrange
            var advertRepo = new Mock<IGenericRepository<Advert>>(); 
            var advertTypesRepo = new Mock<IGenericRepository<AdvertType>>();
            advertRepo.Setup(x => x.GetSet()).Returns(new List<Advert>());
            advertTypesRepo.Setup(x => x.GetSet()).Returns(new List<AdvertType>());

            // Act
            var advertSearchOptionService = new AdvertSearchOptionService(advertRepo.Object, advertTypesRepo.Object);
            var result = advertSearchOptionService.GetSortOptions();

            var expectedResult = new List<SelectOption>();
            expectedResult.Add(new SelectOption("Sortuj po: dacie malejąco", "DateDesc"));
            expectedResult.Add(new SelectOption("Sortuj po: dacie rosnąco", "DateAsc"));
            expectedResult.Add(new SelectOption("Sortuj po: miejscowości malejąco", "CityDesc"));
            expectedResult.Add(new SelectOption("Sortuj po: miejscowości rosnąco", "CityAsc"));
            expectedResult.Add(new SelectOption("Sortuj po: cenie malejąco", "PriceDesc"));
            expectedResult.Add(new SelectOption("Sortuj po: cenie rosnąco", "PriceAsc"));

            // Assert
            Assert.AreEqual(result.Count,expectedResult.Count);

            for (int i = 0; i < expectedResult.Count; i++)
            {
                Assert.AreEqual(expectedResult[i].Text, result[i].Text);
                Assert.AreEqual(expectedResult[i].Value, result[i].Value);
            }

        }

        [TestMethod]
        public void T002_GetPropertyTypes_PropertyTypesWithoutRepeats()
        {
            // Arrange
            var advertRepo = new Mock<IGenericRepository<Advert>>();
            var advertTypesRepo = new Mock<IGenericRepository<AdvertType>>();
            advertRepo.Setup(x => x.GetSet()).Returns(new List<Advert>());

            const string typeName = "Test1";
            const string expectedName = "Nieruchomość: " + typeName;
            advertTypesRepo.Setup(x => x.GetSet()).Returns(new List<AdvertType>(){new AdvertType(){Name = typeName}, new AdvertType(){Name = typeName}});

            // Act
            var advertSearchOptionService = new AdvertSearchOptionService(advertRepo.Object, advertTypesRepo.Object);
            var result = advertSearchOptionService.GetPropertyTypes();

            // Assert
            Assert.AreEqual(result.Count, 1);
            Assert.AreEqual(result[0].Text, expectedName);
            Assert.AreEqual(result[0].Value, typeName);
        }

        [TestMethod]
        public void T003_GetCities_CitiesWithoutRepeats()
        {
            // Arrange
            var advertRepo = new Mock<IGenericRepository<Advert>>();
            var advertTypesRepo = new Mock<IGenericRepository<AdvertType>>();

            const string cityName = "Test1";
            const string expectedCityName = "Miejscowość: " + cityName;
            const string expectedFirstValue = "Miejscowość: Wszystkie";

            IReturnsResult<IGenericRepository<Advert>> returnsResult = advertRepo.Setup(x => x.GetSet()).Returns(new List<Advert>(){new Advert(){City = cityName}, new Advert(){City = cityName}});
            advertTypesRepo.Setup(x => x.GetSet()).Returns(new List<AdvertType>());

            // Act
            var advertSearchOptionService = new AdvertSearchOptionService(advertRepo.Object, advertTypesRepo.Object);
            var result = advertSearchOptionService.GetCities();
            
            // Assert
            Assert.AreEqual(result.Count, 2);
            Assert.AreEqual(result[0].Text, expectedFirstValue);
            Assert.AreEqual(result[0].Value, String.Empty);

            Assert.AreEqual(result[1].Text, expectedCityName);
            Assert.AreEqual(result[1].Value, cityName);
        }

        [TestMethod]
        public void T004_GetAdvertTypes_TwoAdvertTypes()
        {
            // Arrange
            var advertRepo = new Mock<IGenericRepository<Advert>>();
            var advertTypesRepo = new Mock<IGenericRepository<AdvertType>>();
            advertRepo.Setup(x => x.GetSet()).Returns(new List<Advert>());
            advertTypesRepo.Setup(x => x.GetSet()).Returns(new List<AdvertType>());

            // Act
            var advertSearchOptionService = new AdvertSearchOptionService(advertRepo.Object, advertTypesRepo.Object);
            var result = advertSearchOptionService.GetAdvertTypes();

            // Assert
            Assert.AreEqual(result.Count, 2);
            Assert.AreEqual(result[0].Text, "Typ oferty: sprzedaż");
            Assert.AreEqual(result[1].Text, "Typ oferty: wynajem");
            Assert.AreEqual(result[0].Value, "false");
            Assert.AreEqual(result[1].Value, "true");
        }

        [TestMethod]
        public void T005_EmptyRepositories_EmptyListsOfCitiesAndPropertyTypes()
        {
            // Arrange
            var advertRepo = new Mock<IGenericRepository<Advert>>();
            var advertTypesRepo = new Mock<IGenericRepository<AdvertType>>();
            advertRepo.Setup(x => x.GetSet()).Returns(new List<Advert>());
            advertTypesRepo.Setup(x => x.GetSet()).Returns(new List<AdvertType>());

            // Act
            var advertSearchOptionService = new AdvertSearchOptionService(advertRepo.Object, advertTypesRepo.Object);
            var result = advertSearchOptionService.GetOptions();

            // Assert
            Assert.AreEqual(result.Cities.Count, 1);
            Assert.AreEqual(result.PropertyTypes.Count, 0);
            Assert.AreEqual(result.MaxPrice, 2000000);
        }

        [TestMethod]
        public void T006_GetMaxPrice_AdvertListNotEmpty_PriceIsNot2Milions()
        {
            // Arrange
            var advertRepo = new Mock<IGenericRepository<Advert>>();
            var advertTypesRepo = new Mock<IGenericRepository<AdvertType>>();
            
            const int expectedPrice = 123123;
            advertRepo.Setup(x => x.GetSet()).Returns(new List<Advert>(){new Advert(){Price = expectedPrice}});
            advertTypesRepo.Setup(x => x.GetSet()).Returns(new List<AdvertType>());

            // Act
            var advertSearchOptionService = new AdvertSearchOptionService(advertRepo.Object, advertTypesRepo.Object);
            var result = advertSearchOptionService.GetMaxPrice();

            // Assert
            Assert.AreEqual(result, expectedPrice);
        }

    }
}