using System.Collections.Generic;
using System.Linq;
using Context.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Models.ViewModels;
using Moq;
using Services.GenericRepository;
using Services.GetPropertiesByAdvertType.Implementation;

namespace NieruchomosciJG.Tests.ServicesTests
{
    [TestClass]
    public class GetPropertiesByAdvertTypeTests
    {
        private const string Mask2 = "Mask2";
        private const string Mask4 = "Mask4";
        private const string Mask8 = "Mask8";

        [TestMethod]
        public void T001_GetProperties_MaskNotFound_EmptyList()
        {
            // Arrange
            var propRepo = new Mock<IGenericRepository<PropertyDictionary>>();
            propRepo.Setup(x => x.GetSet()).Returns(new List<PropertyDictionary>());

            // Act
            var getPropertiesByAdvertType = new GetPropertiesByAdvertType(propRepo.Object);
            var result = getPropertiesByAdvertType.GetProperties(new AdvertTypeViewModel(){Mask = 1});

            // Assert
            Assert.AreEqual(result.Any(), false);
        }

        [TestMethod]
        public void T002_GetProperties_MasksFound_ProperList()
        {
            // Arrange
            var propRepo = new Mock<IGenericRepository<PropertyDictionary>>();
            var properDict = new List<PropertyDictionary>
            {
                new PropertyDictionary() {Name = Mask2, Mask = 2},
                new PropertyDictionary() {Name = Mask4, Mask = 4},
                new PropertyDictionary() {Name = Mask8, Mask = 8}
            };

            propRepo.Setup(x => x.GetSet()).Returns(properDict);
            // Act
            var getPropertiesByAdvertType = new GetPropertiesByAdvertType(propRepo.Object);
            var result = getPropertiesByAdvertType.GetProperties(new AdvertTypeViewModel() {Mask = 6});

            // Assert
            Assert.AreEqual(result.Count,2);
            Assert.AreEqual(result.First().Name,Mask2);
            Assert.AreEqual(result.Last().Name,Mask4);
        }
    }
}
