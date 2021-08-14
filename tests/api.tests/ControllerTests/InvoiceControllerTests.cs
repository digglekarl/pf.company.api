using api.Controllers;
using api.Models;
using api.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace api.tests.ControllerTests
{
    public class InvoiceControllerTests
    {
        private InvoiceController invoiceController;
        private Mock<IInvoiceService> invoiceServiceMock;

        [SetUp]
        public void SetUp()
        {
            this.invoiceServiceMock = new Mock<IInvoiceService>();
            this.invoiceController = new InvoiceController(this.invoiceServiceMock.Object);
        }

        [Test]
        public void Invoice_Get_ReturnsOk()
        {
            //Arrange

            //Act
            var response = this.invoiceController.Get();
            var result = response as OkObjectResult;

            //Assert
            Assert.That(result, Is.TypeOf<OkObjectResult>());
        }

        [Test]
        public void Invoice_Get_ReturnsList()
        {
            //Arrange
            var expected = new List<Invoice>() { new Invoice { Id = 1, Rate = 100.0M, TotalDays = 10, InvoiceDate = DateTime.Today, Reference = "Ref2507" } };
            this.invoiceServiceMock.Setup(x => x.Get()).Returns(expected);

            //Act
            var response = this.invoiceController.Get();
            var result = response as OkObjectResult;

            var resultList = (List<Invoice>)result.Value;

            //Assert
            Assert.AreEqual(expected.Count, resultList.Count);
        }

        [Test]
        public void Invoice_Get_ReturnsSingle()
        {
            //Arrange
            var expected = new Invoice { Id = 1, Rate = 100.0M, TotalDays = 10, InvoiceDate = DateTime.Today, Reference = "Ref2507" };
            this.invoiceServiceMock.Setup(x => x.Get(1)).Returns(expected);

            //Act
            var response = this.invoiceController.Get(1);
            var result = response as OkObjectResult;

            //Assert
            Assert.AreEqual(expected, result.Value);
        }

        [Test]
        public void Invoice_Post_ReturnsOk()
        {
            //Arrange
            var invoice = new Invoice { Rate = 100.0M, TotalDays = 10, InvoiceDate = DateTime.Today, Reference = "Ref2507" };
            this.invoiceServiceMock.Setup(x => x.Create(invoice)).Returns(true);

            //Act
            var response = this.invoiceController.Post(invoice);
            var result = response as OkObjectResult;

            //Assert
            Assert.That(result, Is.TypeOf<OkObjectResult>());
        }

        [Test]
        public void Invoice_Put_ReturnsOk()
        {
            //Arrange
            var invoice = new Invoice { Id = 1, Rate = 100.0M, TotalDays = 10, InvoiceDate = DateTime.Today, Reference = "Ref2507" };
            this.invoiceServiceMock.Setup(x => x.Update(invoice)).Returns(true);

            //Act
            var response = this.invoiceController.Put(invoice);
            var result = response as OkObjectResult;

            //Assert
            Assert.That(result, Is.TypeOf<OkObjectResult>());
        }

        [Test]
        public void Invoice_Delete_ReturnsOk()
        {
            this.invoiceServiceMock.Setup(x => x.Delete(1)).Returns(true);

            //Act
            var response = this.invoiceController.Delete(1);
            var result = response as OkObjectResult;

            //Assert
            Assert.That(result, Is.TypeOf<OkObjectResult>());
        }
    }
}
