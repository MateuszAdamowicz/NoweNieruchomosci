using System.Collections.Generic;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using Context.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Models.ViewModels;
using Moq;
using Services.CountMessagesAndAdverts.Implementation;
using Services.GenericRepository;

namespace NieruchomosciJG.Tests.ServicesTests
{
    [TestClass]
    public class CountMessagesAndAdvertsTests
    {
        [TestMethod]
        public void T001_CountMessages_EmptyList_0()
        {
            // Arrange
            var messageRepository = new Mock<IGenericRepository<Message>>();
            var advertRepository = new Mock<IGenericRepository<Advert>>();
            messageRepository.Setup(x => x.GetSet()).Returns(new List<Message>());

            // Act
            var countMsgAndAdverts = new CountMessagesAndAdverts(messageRepository.Object, advertRepository.Object);
            var result = countMsgAndAdverts.CountMessages();

            // Assert
            Assert.AreEqual(result, 0);
        }

        [TestMethod]
        public void T002_CountMessages_FilledList_CorrectNumberOfMsg()
        {
            // Arrange
            var messageRepository = new Mock<IGenericRepository<Message>>();
            var advertRepository = new Mock<IGenericRepository<Advert>>();
            messageRepository.Setup(x => x.GetSet()).Returns(new List<Message>(){new Message(), new Message(), new Message()});

            // Act
            var countMsgAndAdverts = new CountMessagesAndAdverts(messageRepository.Object, advertRepository.Object);
            var result = countMsgAndAdverts.CountMessages();

            // Assert
            Assert.AreEqual(result, 3);
        }

        [TestMethod]
        public void T003_CountAdvert_EmptyList_0()
        {
            // Arrange
            var messageRepository = new Mock<IGenericRepository<Message>>();
            var advertRepository = new Mock<IGenericRepository<Advert>>();
            advertRepository.Setup(x => x.GetSet()).Returns(new List<Advert>());

            // Act
            var countMsgAndAdverts = new CountMessagesAndAdverts(messageRepository.Object, advertRepository.Object);
            var result = countMsgAndAdverts.CountAdvert();
            
            // Assert
            Assert.AreEqual(result, 0);
        }

        [TestMethod]
        public void T004_CountAdvert_FilledList_GetOnlyVisibleAdverts()
        {
            // Arrange
            var messageRepository = new Mock<IGenericRepository<Message>>();
            var advertRepository = new Mock<IGenericRepository<Advert>>();
            advertRepository.Setup(x => x.GetSet()).Returns(new List<Advert>(){new Advert(){Visible = true}, new Advert(){Visible = true}, new Advert()});

            // Act
            var countMsgAndAdverts = new CountMessagesAndAdverts(messageRepository.Object, advertRepository.Object);
            var result = countMsgAndAdverts.CountAdvert();

            // Assert
            Assert.AreEqual(result, 2);
        }

        [TestMethod]
        public void T005_Count_CouningWorks()
        {
            // Arrange
            var messageRepository = new Mock<IGenericRepository<Message>>();
            var advertRepository = new Mock<IGenericRepository<Advert>>();
            advertRepository.Setup(x => x.GetSet()).Returns(new List<Advert>() { new Advert() { Visible = true }, new Advert() { Visible = true }, new Advert() });
            messageRepository.Setup(x => x.GetSet()).Returns(new List<Message>() { new Message(), new Message(), new Message() });
        
            // Act
            var countMsgAndAdverts = new CountMessagesAndAdverts(messageRepository.Object, advertRepository.Object);
            var result = countMsgAndAdverts.Count(new AdminMenuViewModel());

            // Assert
            Assert.AreEqual(result.AdvertsCount, 2);
            Assert.AreEqual(result.MessagesCount,3);
        }

    }
}