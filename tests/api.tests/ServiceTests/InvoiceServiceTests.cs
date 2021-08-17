
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
        private Mock<IBaseRepository> baseRepositoryMock;

        [SetUp]
        public void SetUp()
        {
            this.baseRepositoryMock = new Mock<IBaseRepository>();
            this.invoiceService = new InvoiceService(this.baseRepositoryMock.Object);
        }

        [Test]
        public void Get_NoInvoices_ReturnsEmptyList()
        {
            //Arrange
            var expected = new List<Invoice>();
            this.baseRepositoryMock.Setup(x => x.Get<Invoice>(It.IsAny<string>())).Returns(expected);
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
            this.baseRepositoryMock.Setup(x => x.Get<Invoice>(It.IsAny<string>())).Returns(expected);
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
            this.baseRepositoryMock.Setup(x => x.Get<Invoice>(1, It.IsAny<string>(), It.IsAny<object>())).Returns(expected);
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
            this.baseRepositoryMock.Setup(x => x.Create<Invoice>(invoice, It.IsAny<string>(), It.IsAny<object>())).Returns(true);

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
            this.baseRepositoryMock.Setup(x => x.Create<Invoice>(invoice, It.IsAny<string>(), It.IsAny<object>())).Returns(false);

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
            this.baseRepositoryMock.Setup(x => x.Update<Invoice>(invoice, It.IsAny<string>(), It.IsAny<object>())).Returns(true);
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
            this.baseRepositoryMock.Setup(x => x.Update<Invoice>(invoice, It.IsAny<string>(), It.IsAny<object>())).Returns(false);
            //Act
            var result = this.invoiceService.Update(invoice);

            //Assert
            Assert.IsFalse(result);
        }

        [Test]
        public void Delete_IsDeleted_ReturnsTrue()
        {
            //Arrange
            this.baseRepositoryMock.Setup(x => x.Delete(1, It.IsAny<string>(), It.IsAny<object>())).Returns(true);

            //Act
            var result = this.invoiceService.Delete(1);

            //Assert
            Assert.IsTrue(result);
        }

        [Test]
        public void Delete_IsNotDeleted_ReturnsFalse()
        {
            //Arrange
            this.baseRepositoryMock.Setup(x => x.Delete(1, It.IsAny<string>(), It.IsAny<object>())).Returns(false);

            //Act
            var result = this.invoiceService.Delete(1);

            //Assert
            Assert.IsFalse(result);
        }

        [Test]
        [TestCase(100, 10, 1000)]
        [TestCase(365, 20, 7300)]
        public void Invoice_WhenRetrieved_CalculatesAmount(decimal rate, int days, decimal total)
        {
            //Arrange
            var invoice = new Invoice { Id = 1, Rate = rate, TotalDays = days, InvoiceDate = DateTime.Today, Reference = "Ref2507" };
            this.baseRepositoryMock.Setup(x => x.Get<Invoice>(1, It.IsAny<string>(), It.IsAny<object>())).Returns(invoice);

            //Act
            var result = this.invoiceService.Get(1);

            //Assert
            Assert.AreEqual(total, result.Amount);
        }


        [Test]
        [TestCase(100, 10, 200)]
        [TestCase(365, 20, 1460)]
        public void Invoice_WhenRetrieved_CalculatesVAT(decimal rate, int days, decimal total)
        {
            //Arrange
            var invoice = new Invoice { Id = 1, Rate = rate, TotalDays = days, InvoiceDate = DateTime.Today, Reference = "Ref2507" };
            this.baseRepositoryMock.Setup(x => x.Get<Invoice>(1, It.IsAny<string>(), It.IsAny<object>())).Returns(invoice);

            //Act
            var result = this.invoiceService.Get(1);

            //Assert
            Assert.AreEqual(total, result.Vat);
        }

        [Test]
        [TestCase(100, 10, 1200)]
        [TestCase(365, 20, 8760)]
        public void Invoice_WhenRetrieved_CalculatesTotalAmount(decimal rate, int days, decimal total)
        {
            //Arrange
            var invoice = new Invoice { Id = 1, Rate = rate, TotalDays = days, InvoiceDate = DateTime.Today, Reference = "Ref2507" };
            this.baseRepositoryMock.Setup(x => x.Get<Invoice>(1, It.IsAny<string>(), It.IsAny<object>())).Returns(invoice);

            //Act
            var result = this.invoiceService.Get(1);

            //Assert
            Assert.AreEqual(total, result.TotalAmount);
        }
    }
}
