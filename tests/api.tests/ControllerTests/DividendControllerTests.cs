using api.Controllers;
using api.Models;
using api.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace api.tests.controllers
{
    public class DividendControllerTests
    {
        private DividendController dividendsController;
        private Mock<IDividendService> dividendService;

        [SetUp]
        public void Setup()
        {
            this.dividendService = new Mock<IDividendService>();
            this.dividendsController = new DividendController(this.dividendService.Object);
        }

        [Test]
        public void Dividend_Get_ReturnsOk()
        {
            //Arrange
            
            //Act
            var response = this.dividendsController.Get();
            var result = response as OkObjectResult;

            //Assert
            Assert.That(result, Is.TypeOf<OkObjectResult>());
        }

        [Test]
        public void Dividend_Get_ReturnsList()
        {
            //Arrange
            var expected = new List<Dividend>() { new Dividend { Id = 1, Reference = "Ref2507", RequestedDate = DateTime.Now, Amount = 1000.00M } };
            this.dividendService.Setup(x => x.Get()).Returns(expected);
           
            //Act
            var response = this.dividendsController.Get();
            var result = response as OkObjectResult;

            var resultList = (List<Dividend>)result.Value;

            //Assert
            Assert.AreEqual(expected.Count, resultList.Count);
        }

        [Test]
        public void Dividend_Get_ReturnsSingle()
        {
            //Arrange
            var expected = new Dividend { Id = 1, Reference = "Ref2507", RequestedDate = DateTime.Now, Amount = 1000.00M };
            this.dividendService.Setup(x => x.Get(1)).Returns(expected);

            //Act
            var response = this.dividendsController.Get(1);
            var result = response as OkObjectResult;

            //Assert
            Assert.AreEqual(expected, result.Value);
        }

        [Test]
        public void Dividend_Post_ReturnsOk()
        {
            //Arrange
            var dividend = new Dividend { Reference = "Ref2507", RequestedDate = DateTime.Now, Amount = 1500.00M };

            //Act
            var response = this.dividendsController.Post(dividend);
            var result = response as OkObjectResult;

            //Assert
            Assert.That(result, Is.TypeOf<OkObjectResult>());
        }

        [Test]
        public void Dividend_Put_ReturnsOk()
        {
            //Arrange
            var dividend = new Dividend { Id = 1, Reference = "Ref250781", RequestedDate = DateTime.Now, Amount = 1500.00M };

            //Act
            var response = this.dividendsController.Put(1, dividend);
            var result = response as OkObjectResult;

            //Assert
            Assert.That(result, Is.TypeOf<OkObjectResult>());
        }

        [Test]
        public void Dividend_Delete_ReturnsOk()
        {
            //Arrange
            
            //Act
            var response = this.dividendsController.Delete(1);
            var result = response as OkObjectResult;

            //Assert
            Assert.That(result, Is.TypeOf<OkObjectResult>());
        }
    }
}