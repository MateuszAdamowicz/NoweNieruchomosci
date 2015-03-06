using System;
using System.Collections.Generic;
using Context.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Services.GenericRepository;
using Services.GetAdvertTypes.Implementation;

namespace NieruchomosciJG.Tests.ServicesTests
{
    [TestClass]
    public class GetAdvertTypesTest
    {
        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void T001_FindAdvertTypeByMask_MaskNotFound_InvalidOperationException()
        {
            // Arrange
            var advertTypeRepo = new Mock<IGenericRepository<AdvertType>>();
            advertTypeRepo.Setup(x => x.GetSet()).Returns(new List<AdvertType>());

            // Act
            var getAdvertTypes = new GetAdvertTypes(advertTypeRepo.Object);
            var result = getAdvertTypes.FindAdvertTypeByMask(10);

            // Assert
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void T002_FindAdvertTypeByMask_MoreThanOneAdvertTypeFound_InvalidOperationException()
        {
            // Arrange
            var advertTypeRepo = new Mock<IGenericRepository<AdvertType>>();
            advertTypeRepo.Setup(x => x.GetSet()).Returns(new List<AdvertType>(){new AdvertType(){Mask = 2}, new AdvertType(){Mask = 2}});

            // Act
            var advertTypes = new GetAdvertTypes(advertTypeRepo.Object);
            advertTypes.FindAdvertTypeByMask(2);

            // Assert
        }
    }
}