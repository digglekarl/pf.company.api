using api.Models;
using api.Repositories;
using api.Repositories.Interfaces;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace api.tests.RepositoryTests
{
    public class DividendRepositoryTests
    {
        private DividendRepository dividendRepository;
        private Mock<IDapperExecutor> dapperExecutorMock;
        [SetUp]
        public void SetUp()
        {
            this.dapperExecutorMock = new Mock<IDapperExecutor>();
            this.dividendRepository = new DividendRepository(this.dapperExecutorMock.Object);
        }

        [Test]
        public void Get_NoDividends_ReturnsEmptyList()
        {
            //Arrange
            var expected = new List<Dividend>();

            //Act
            var result = this.dividendRepository.Get<Dividend>(It.IsAny<string>());

            //Assert
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void Get_DividendsExist_ReturnsList()
        {
            //Arrange
            var expected = new List<Dividend>() { new Dividend { Id = 1, Reference = "Ref2507", RequestedDate = DateTime.Now, Amount = 1000.00M } };
            this.dapperExecutorMock.Setup(x => x.Query<Dividend>(It.IsAny<IDbConnection>(), It.IsAny<string>(), It.IsAny<object>())).Returns(expected);

            //Act
            var result = this.dividendRepository.Get<Dividend>(It.IsAny<string>());

            //Assert
            Assert.AreEqual(expected, result);
        }

        [Test]

        public void Get_DividendById_ReturnsDividend()
        {
            //Arrange
            var expected = new Dividend { Id = 1, Reference = "Ref2507", RequestedDate = DateTime.Now, Amount = 1000.00M };
            this.dapperExecutorMock.Setup(x => x.QuerySingle<Dividend>(It.IsAny<IDbConnection>(), It.IsAny<string>(), It.IsAny<object>())).Returns(expected);

            //Act
            var result = this.dividendRepository.Get<Dividend>(1, It.IsAny<string>(), It.IsAny<object>());

            //Assert
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void Create_IsCreated_ReturnsTrue()
        {
            //Arrange
            var dividend = new Dividend { Reference = "Ref2507", RequestedDate = DateTime.Now, Amount = 1000.00M };

            this.dapperExecutorMock.Setup(x => x.Execute(It.IsAny<IDbConnection>(), It.IsAny<string>(), It.IsAny<object>())).Returns(1);
            //Act
            var result = this.dividendRepository.Create<Dividend>(dividend, It.IsAny<string>(), It.IsAny<object>());

            //Assert
            Assert.IsTrue(result);
        }

        [Test]
        public void Create_IsNotCreated_ReturnsTrue()
        {
            //Arrange
            var dividend = new Dividend { Reference = "Ref2507", RequestedDate = DateTime.Now, Amount = 1000.00M };
            this.dapperExecutorMock.Setup(x => x.Execute(It.IsAny<IDbConnection>(), It.IsAny<string>(), It.IsAny<object>())).Returns(-1);

            //Act
            var result = this.dividendRepository.Create<Dividend>(dividend, It.IsAny<string>(), It.IsAny<object>());

            //Assert
            Assert.IsFalse(result);
        }

        [Test]
        public void Update_IsUpdated_ReturnsTrue()
        {
            //Arrange
            var dividend = new Dividend { Id = 1, Reference = "Ref2507", RequestedDate = DateTime.Now, Amount = 1000.00M };
            this.dapperExecutorMock.Setup(x => x.Execute(It.IsAny<IDbConnection>(), It.IsAny<string>(), It.IsAny<object>())).Returns(1);
            //Act
            var result = this.dividendRepository.Update<Dividend>(dividend, It.IsAny<string>(), It.IsAny<object>());

            //Assert
            Assert.IsTrue(result);
        }

        [Test]
        public void Update_IsNotUpdated_ReturnsFalse()
        {
            //Arrange
            var dividend = new Dividend { Id = 1, Reference = "Ref2507", RequestedDate = DateTime.Now, Amount = 1000.00M };
            this.dapperExecutorMock.Setup(x => x.Execute(It.IsAny<IDbConnection>(), It.IsAny<string>(), It.IsAny<object>())).Returns(-1);

            //Act
            var result = this.dividendRepository.Update<Dividend>(dividend, It.IsAny<string>(), It.IsAny<object>());

            //Assert
            Assert.IsFalse(result);
        }

        [Test]
        public void Delete_IsDeleted_ReturnsTrue()
        {
            //Arrange
            this.dapperExecutorMock.Setup(x => x.Execute(It.IsAny<IDbConnection>(), It.IsAny<string>(), It.IsAny<object>())).Returns(1);

            //Act
            var result = this.dividendRepository.Delete(1, It.IsAny<string>(), It.IsAny<object>());

            //Assert
            Assert.IsTrue(result);
        }

        [Test]
        public void Delete_IsNotDeleted_ReturnsFalse()
        {
            //Arrange
            this.dapperExecutorMock.Setup(x => x.Execute(It.IsAny<IDbConnection>(), It.IsAny<string>(), It.IsAny<object>())).Returns(-1);

            //Act
            var result = this.dividendRepository.Delete(1, It.IsAny<string>(), It.IsAny<object>());

            //Assert
            Assert.IsFalse(result);
        }
    }
}
