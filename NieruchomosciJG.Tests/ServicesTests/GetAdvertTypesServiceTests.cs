using System;
using System.Collections.Generic;
using System.Linq;
using Context.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Services.GenericRepository;
using Services.GetAdvertTypes.Implementation;

namespace NieruchomosciJG.Tests.ServicesTests
{
    [TestClass]
    public class GetAdvertTypesServiceTests
    {
        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void  T001_FindAdvertTypeByMask_MaskNotFound_Exception()
        {
            // Arrange
            var advertTypeRepo = new Mock<IGenericRepository<AdvertType>>();
            advertTypeRepo.Setup(x => x.GetSet()).Returns(new List<AdvertType>{new AdvertType(){Mask = 1}, new AdvertType{Mask = 1}});

            // Act
            var getAdvertTypes = new GetAdvertTypes(advertTypeRepo.Object);
            var result = getAdvertTypes.FindAdvertTypeByMask(0);
        }

        [TestMethod]
        [ExpectedException(typeof (InvalidOperationException))]
        public void T002_FindAdvertTypeByMask_SequenceContainsMoreThanOneElement_Exception()
        {
            // Arrange
            var advertTypeRepo = new Mock<IGenericRepository<AdvertType>>();
            advertTypeRepo.Setup(x => x.GetSet()).Returns(new List<AdvertType>());

            // Act

            var getAdvertTypes = new GetAdvertTypes(advertTypeRepo.Object);
            var result = getAdvertTypes.FindAdvertTypeByMask(1);

        }

        [TestMethod]
        public void T003_GetAdvertTypeNameAndMask_EmptyListOfAdvertTypes_EmptyList()
        {
            // Arrange
            var advertTypeRepo = new Mock<IGenericRepository<AdvertType>>();
            advertTypeRepo.Setup(x => x.GetSet()).Returns(new List<AdvertType>());

            // Act
            var getAdvertTypes = new GetAdvertTypes(advertTypeRepo.Object);
            var result = getAdvertTypes.GetAdvertTypeNameAndMask();

            // Assert
            Assert.AreEqual(result.Any(), false);
        }
    }
}
