
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

namespace api.tests.ServiceTests
{
    public class InvoiceServiceTests
    {
        private InvoiceService invoiceService;
        private Mock<IInvoiceRepository> invoiceRepositoryMock;

        [SetUp]
        public void SetUp()
        {
            this.invoiceRepositoryMock = new Mock<IInvoiceRepository>();
            this.invoiceService = new InvoiceService(this.invoiceRepositoryMock.Object);
        }

        [Test]
        public void Get_NoInvoices_ReturnsEmptyList()
        {
            //Arrange
            var expected = new List<Invoice>();
            this.invoiceRepositoryMock.Setup(x => x.Get()).Returns(expected);
            //Act
            var result = this.invoiceService.Get();

            //Assert
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void Get_Invoices_ReturnsList()
        {
            //Arrange
            var expected = new List<Invoice>() { new Invoice { Id = 1, Rate = 100.0M, TotalDays = 10, InvoiceDate = DateTime.Today, Reference = "Ref2507" } };
            this.invoiceRepositoryMock.Setup(x => x.Get()).Returns(expected);
            //Act
            var result = this.invoiceService.Get();

            //Assert
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void Get_InvoiceById_ReturnsInvoice()
        {
            //Arrange
            var expected = new Invoice { Id = 1, Rate = 100.0M, TotalDays = 10, InvoiceDate = DateTime.Today, Reference = "Ref2507" };
            this.invoiceRepositoryMock.Setup(x => x.Get(1)).Returns(expected);
            //Act
            var result = this.invoiceService.Get(1);

            //Assert
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void Create_IsCreated_RetrunsTrue()
        {
            //Arrange
            var invoice = new Invoice { Rate = 100.0M, TotalDays = 10, InvoiceDate = DateTime.Today, Reference = "Ref2507" };
            this.invoiceRepositoryMock.Setup(x => x.Create(invoice)).Returns(true);

            //Act
            var result = this.invoiceService.Create(invoice);

            //Assert
            Assert.IsTrue(result);
        }

        [Test]
        public void Create_IsNotCreated_RetrunsTrue()
        {
            //Arrange
            var invoice = new Invoice { Rate = 100.0M, TotalDays = 10, InvoiceDate = DateTime.Today, Reference = "Ref2507" };
            this.invoiceRepositoryMock.Setup(x => x.Create(invoice)).Returns(false);

            //Act
            var result = this.invoiceService.Create(invoice);

            //Assert
            Assert.IsFalse(result);
        }

        [Test]
        public void Update_IsUpdated_ReturnsTrue()
        {
            //Arrange
            var invoice = new Invoice { Id = 1, Rate = 100.0M, TotalDays = 10, InvoiceDate = DateTime.Today, Reference = "Ref2507" };
            this.invoiceRepositoryMock.Setup(x => x.Update(invoice)).Returns(true);
            //Act
            var result = this.invoiceService.Update(invoice);

            //Assert
            Assert.IsTrue(result);
        }

        [Test]
        public void Update_IsNotUpdated_ReturnsFalse()
        {
            //Arrange
            var invoice = new Invoice { Id = 1, Rate = 100.0M, TotalDays = 10, InvoiceDate = DateTime.Today, Reference = "Ref2507" };
            this.invoiceRepositoryMock.Setup(x => x.Update(invoice)).Returns(false);
            //Act
            var result = this.invoiceService.Update(invoice);

            //Assert
            Assert.IsFalse(result);
        }

        [Test]
        public void Delete_IsDeleted_ReturnsTrue()
        {
            //Arrange
            this.invoiceRepositoryMock.Setup(x => x.Delete(1)).Returns(true);

            //Act
            var result = this.invoiceService.Delete(1);

            //Assert
            Assert.IsTrue(result);
        }

        [Test]
        public void Delete_IsNotDeleted_ReturnsFalse()
        {
            //Arrange
            this.invoiceRepositoryMock.Setup(x => x.Delete(1)).Returns(false);

            //Act
            var result = this.invoiceService.Delete(1);

            //Assert
            Assert.IsFalse(result);
        }
    }
}
