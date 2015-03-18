using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Models.ViewModels;
using Moq;
using Services.DetailedSortService;
using Services.SortAdvertService.Implementation;

namespace NieruchomosciJG.Tests.ServicesTests
{
    [TestClass]
    public class SortAdvertServiceTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void T001_SortAdverts_AdvertsToShowIsNull_ArgumentNullException()
        {
            // Arrange
            var detailedSortService = new Mock<IDetailedSortService>();

            // Act
            var sortAdvertService = new SortAdvertService(detailedSortService.Object);
            var result = sortAdvertService.SortAdverts(null, null, false);

            // Assert
        }

        [TestMethod]
        public void T002_SortAdverts_SortOptionIsNull_OrderByDescendingCreatedTime()
        {
            // Arrange
            var detailedSortService = new Mock<IDetailedSortService>();

            // Act
            var sortAdvertService = new SortAdvertService(detailedSortService.Object);
            var result = sortAdvertService.SortAdverts(new List<AdminAdvertToShow>(){new AdminAdvertToShow(){Id = 1, CreatedAt = new DateTime(2012,10,10)}, new AdminAdvertToShow(){Id = 2, CreatedAt = new DateTime(2013,10,10)}}, null, false).ToList();

            // Assert
            Assert.AreEqual(result.Count(), 2 );
            Assert.AreEqual(result.First().Id,2);
            Assert.AreEqual(result.Last().Id,1);
        }

        [TestMethod]
        public void T003_SortAdverts_AdminSortOptionIsNotNullSortDescReturn_ReversedList()
        {
            // Arrange
            var detailedSortService = new Mock<IDetailedSortService>();
            detailedSortService.Setup(x => x.Sort(It.IsAny<AdminSortOption>(), It.IsAny<List<AdminAdvertToShow>>()))
                .Returns(new List<AdminAdvertToShow>(){new AdminAdvertToShow(){Id = 1}, new AdminAdvertToShow(){Id = 2}});

            // Act
            var sortAdvertService = new SortAdvertService(detailedSortService.Object);
            var result = sortAdvertService.SortAdverts(new List<AdminAdvertToShow>(), AdminSortOption.Area, true).ToList();

            // Assert
            Assert.AreEqual(result.First().Id, 2);
            Assert.AreEqual(result.Last().Id,1);
        }
    }
}