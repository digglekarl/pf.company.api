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
    public class InvoiceRepositoryTests
    {
        private InvoiceRepository invoiceRepository;
        private Mock<IDapperExecutor> dapperExecutor;

        [SetUp]
        public void SetUp()
        {
            this.dapperExecutor = new Mock<IDapperExecutor>();
            this.invoiceRepository = new InvoiceRepository(this.dapperExecutor.Object);
        }

        [Test]
        public void Get_NoInvoices_ReturnsEmptyList()
        {
            //Arrange
            var expected = new List<Invoice>();

            //Act
            var result = this.invoiceRepository.Get<Invoice>(It.IsAny<string>());

            //Assert
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void Get_InvoicesExist_ReturnsList()
        {
            //Arrange
            var expected = new List<Invoice>() { new Invoice { Id = 1, Rate = 100.0M, TotalDays = 10, InvoiceDate = DateTime.Today, Reference = "Ref2507" } };
            this.dapperExecutor.Setup(x => x.Query<Invoice>(It.IsAny<IDbConnection>(), It.IsAny<string>(), It.IsAny<object>())).Returns(expected);

            //Act
            var result = this.invoiceRepository.Get<Invoice>(It.IsAny<string>());

            //Assert
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void Get_InvoiceById_ReturnsInvoice()
        {
            //Arrange
            var expected = new Invoice { Id = 1, Rate = 100.0M, TotalDays = 10, InvoiceDate = DateTime.Today, Reference = "Ref2507" };
            this.dapperExecutor.Setup(x => x.QuerySingle<Invoice>(It.IsAny<IDbConnection>(), It.IsAny<string>(), It.IsAny<object>())).Returns(expected);
            
            //Act
            var result = this.invoiceRepository.Get<Invoice>(1, It.IsAny<string>(), It.IsAny<object>());

            //Assert
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void Create_IsCreated_ReturnsTrue()
        {
            //Arrange
            var invoice = new Invoice { InvoiceDate = DateTime.Today, Rate = 100.0M, TotalDays = 10, Reference = "Ref1234" };
            this.dapperExecutor.Setup(x => x.Execute(It.IsAny<IDbConnection>(), It.IsAny<string>(), It.IsAny<object>())).Returns(1);
            
            //Act
            var result = this.invoiceRepository.Create<Invoice>(invoice, It.IsAny<string>(), It.IsAny<object>());

            //Assert
            Assert.IsTrue(result);
        }

        [Test]
        public void Create_IsNotCreated_ReturnsFalse()
        {
            //Arrange
            var invoice = new Invoice { InvoiceDate = DateTime.Today, Rate = 100.0M, TotalDays = 10, Reference = "Ref1234" };
            this.dapperExecutor.Setup(x => x.Execute(It.IsAny<IDbConnection>(), It.IsAny<string>(), It.IsAny<object>())).Returns(-1);

            //Act
            var result = this.invoiceRepository.Create<Invoice>(invoice, It.IsAny<string>(), It.IsAny<object>());

            //Assert
            Assert.IsFalse(result);
        }

        [Test]
        public void Update_IsUpdated_ReturnsTrue()
        {
            //Arrange
            var invoice = new Invoice { Id=1, InvoiceDate = DateTime.Today, Rate = 100.0M, TotalDays = 15, Reference = "Ref1234" };
            this.dapperExecutor.Setup(x => x.Execute(It.IsAny<IDbConnection>(), It.IsAny<string>(), It.IsAny<object>())).Returns(1);

            //Act
            var result = this.invoiceRepository.Update<Invoice>(invoice, It.IsAny<string>(), It.IsAny<object>());

            //Assert
            Assert.IsTrue(result);
        }

        [Test]
        public void Update_IsNotUpdated_ReturnsFalse()
        {
            //Arrange
            var invoice = new Invoice { Id = 1, InvoiceDate = DateTime.Today, Rate = 100.0M, TotalDays = 15, Reference = "Ref1234" };
            this.dapperExecutor.Setup(x => x.Execute(It.IsAny<IDbConnection>(), It.IsAny<string>(), It.IsAny<object>())).Returns(-1);

            //Act
            var result = this.invoiceRepository.Update<Invoice>(invoice, It.IsAny<string>(), It.IsAny<object>());

            //Assert
            Assert.IsFalse(result);
        }

        [Test]
        public void Delete_IsDeleted_ReturnsTrue()
        {
            //Arrange
            this.dapperExecutor.Setup(x => x.Execute(It.IsAny<IDbConnection>(), It.IsAny<string>(), It.IsAny<object>())).Returns(1);

            //Act
            var result = this.invoiceRepository.Delete(1, It.IsAny<string>(), It.IsAny<object>());

            //Assert
            Assert.IsTrue(result);
        }

        [Test]
        public void Delete_IsNotDeleted_RetiurnsFalse()
        {
            //Arrange
            this.dapperExecutor.Setup(x => x.Execute(It.IsAny<IDbConnection>(), It.IsAny<string>(), It.IsAny<object>())).Returns(-1);

            //Act
            var result = this.invoiceRepository.Delete(1, It.IsAny<string>(), It.IsAny<object>());

            //Assert
            Assert.IsFalse(result);
        }
    }
}
