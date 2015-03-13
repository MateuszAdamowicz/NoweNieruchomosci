using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Context.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using NieruchomosciJG.App_Start;
using Services.GenericRepository;
using Services.NewestAdvertsService.Implementation;

namespace NieruchomosciJG.Tests.ServicesTests
{
    [TestClass]
    public class NewestAdvertsServiceTest
    {
        public NewestAdvertsServiceTest()
        {
            MapperConfig.Register();
        }

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

        [TestMethod]
        public void T003_GetNewest_OrderDescendingByDate()
        {
            // Arrange
            var advertRepo = new Mock<IGenericRepository<Advert>>();
            advertRepo.Setup(x => x.GetSet()).Returns(new List<Advert>(){new Advert(){Id = 1,Photos = new List<Photo>(),Visible = true,CreatedAt = new DateTime(2013,10,10)}, new Advert(){Photos = new List<Photo>(),Id = 2,Visible = true,CreatedAt = new DateTime(1992,10,17)}});

            // Act
            var newestAdvertService = new NewestAdvertsService(advertRepo.Object);
            var result = newestAdvertService.GetNewest(2);

            // Assert
            Assert.AreEqual(result.First().CreatedAt, new DateTime(2013,10,10));
            Assert.AreEqual(result.Last().CreatedAt, new DateTime(1992,10,17));
        }

        [TestMethod]
        public void T004_GetNewest_GetOnlyVisibleAdverts()
        {
            // Arrange
            var advertRepo = new Mock<IGenericRepository<Advert>>();
            advertRepo.Setup(x => x.GetSet()).Returns(new List<Advert>() {new Advert(){Id = 1, Photos = new List<Photo>(),Visible = true}, new Advert(){Photos = new List<Photo>(),Id=2,Visible = false}});

            // Act
            var newestAdvertService = new NewestAdvertsService(advertRepo.Object);
            var result = newestAdvertService.GetNewest(2);

            // Assert
            Assert.AreEqual(result.Count(), 1);
            Assert.AreEqual(result.First().Number, 1);
        }
    }
}