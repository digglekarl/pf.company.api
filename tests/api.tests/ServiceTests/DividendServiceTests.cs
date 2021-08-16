using api.Models;
using api.Repositories.Interfaces;
using api.Services;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace api.tests.Services
{
    public class DividendServiceTests
    {
        private DividendService dividendService;
        private Mock<IBaseRepository> baseRepositoryMock;

        [SetUp]
        public void SetUp()
        {
            this.baseRepositoryMock = new Mock<IBaseRepository>();

            this.dividendService = new DividendService(this.baseRepositoryMock.Object);
        }

        [Test]
        public void Get_NoDividendsExist_ReturnsEmptyList()
        {
            //Arrange
            var expected = new List<Dividend>();
            this.baseRepositoryMock.Setup(x => x.Get<Dividend>(It.IsAny<string>())).Returns(expected);

            //Act
            var result = this.dividendService.Get();

            //Assert
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void Get_DividendsExist_ReturnsList()
        {
            //Arrange
            var expected = new List<Dividend>() { new Dividend { Id = 1, Reference = "Ref2507", RequestedDate = DateTime.Now, Amount = 1000.00M } };
            this.baseRepositoryMock.Setup(x => x.Get<Dividend>(It.IsAny<string>())).Returns(expected);
           
            //Act
            var result = this.dividendService.Get();

            //Assert
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void Get_DividendById_ReturnsSingle()
        {
            //Arrange
            var expected = new Dividend { Id = 1, Reference = "Ref2507", RequestedDate = DateTime.Now, Amount = 1500.00M };
            this.baseRepositoryMock.Setup(x => x.Get<Dividend>(1, It.IsAny<string>(), It.IsAny<object>())).Returns(expected);

            //Act
            var result = this.dividendService.Get(1);

            //Assert
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void Create_IsCreated_ReturnsTrue()
        {
            //Arrange
            var dividend = new Dividend { Reference = "Ref2507", RequestedDate = DateTime.Now, Amount = 1500.00M };
            this.baseRepositoryMock.Setup(x => x.Create(dividend, It.IsAny<string>(), It.IsAny<object>())).Returns(true);

            //Act
            var result = this.dividendService.Create(dividend);

            //Assert
            Assert.IsTrue(result);
        }

        [Test]
        public void Create_IsNotCreated_ReturnsFalse()
        {
            //Arrange
            var dividend = new Dividend { Reference = "Ref2507", RequestedDate = DateTime.Now, Amount = 1500.00M };
            this.baseRepositoryMock.Setup(x => x.Create(dividend, It.IsAny<string>(), It.IsAny<object>())).Returns(false);

            //Act
            var result = this.dividendService.Create(dividend);

            //Assert
            Assert.IsFalse(result);
        }

        [Test]
        public void Update_IsUpdated_ReturnsTrue()
        {
            //Arrange
            var dividend = new Dividend { Id = 1, Reference = "Ref2507", RequestedDate = DateTime.Now, Amount = 1500.00M };
            this.baseRepositoryMock.Setup(x => x.Update(dividend, It.IsAny<string>(), It.IsAny<object>())).Returns(true);

            //Act
            var result = this.dividendService.Update(dividend);

            //Assert
            Assert.IsTrue(result);
        }

        [Test]
        public void Update_IsUpdated_ReturnsFalse()
        {
            //Arrange
            var dividend = new Dividend { Id = 1, Reference = "Ref2507", RequestedDate = DateTime.Now, Amount = 1500.00M };
            this.baseRepositoryMock.Setup(x => x.Update(dividend, It.IsAny<string>(), It.IsAny<object>())).Returns(false);

            //Act
            var result = this.dividendService.Update(dividend);

            //Assert
            Assert.IsFalse(result);
        }

        [Test]
        public void Delete_IsDeleted_ReturnsTrue()
        {
            //Arrange
            this.baseRepositoryMock.Setup(x => x.Delete(1, It.IsAny<string>(), It.IsAny<object>())).Returns(true);

            //Act
            var result = this.dividendService.Delete(1);

            //Assert
            Assert.IsTrue(result);
        }

        [Test]
        public void Delete_IsNotDeleted_ReturnsFalse()
        {
            //Arrange
            this.baseRepositoryMock.Setup(x => x.Delete(1, It.IsAny<string>(), It.IsAny<object>())).Returns(false);

            //Act
            var result = this.dividendService.Delete(1);

            //Assert
            Assert.IsFalse(result);
        }
    }
}
