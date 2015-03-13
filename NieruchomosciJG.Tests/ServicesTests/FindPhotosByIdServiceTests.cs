using System;
using System.Collections.Generic;
using System.Linq;
using Context.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Services.GenericRepository;

namespace NieruchomosciJG.Tests
{
    [TestClass]
    public class FindPhotosByIdServiceTests
    {
        [TestMethod]
        public void T001_EmptyPhotoIntCollection_ReturnsEmptyPhotoCollection()
        {
            // Arrange
            var photoRepository = new Mock<IGenericRepository<Photo>>();
            photoRepository.Setup(x => x.Find(It.IsAny<int>())).Returns(new Photo());

            // Act
            var findPhotoById = new Services.FindPhotosById.Implementation.FindPhotosByIdService(photoRepository.Object);

            var intList = new List<int>();
            var result = findPhotoById.Find(intList);

            // Assert
            Assert.AreEqual(0, result.Count());
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void T002_NullPhotoIntCollection_ArgumentNullException()
        {
            // Arrange
            var photoRepository = new Mock<IGenericRepository<Photo>> ();
            photoRepository.Setup(x => x.Find(It.IsAny<int>())).Returns(new Photo());

            // Act
            var findPhotoById = new Services.FindPhotosById.Implementation.FindPhotosByIdService(photoRepository.Object);

            var result = findPhotoById.Find(null);
        }
    }
}