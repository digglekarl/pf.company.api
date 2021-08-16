using api.Controllers;
using api.Models;
using api.Services;
using api.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;


namespace api.tests.ControllerTests
{
    public class CompanyControllerTests
    {
        private CompanyController companyController;
        private Mock<ICompanyService> companyServiceMock;

        [SetUp]
        public void SetUp()
        {
            this.companyServiceMock = new Mock<ICompanyService>();
            this.companyController = new CompanyController(this.companyServiceMock.Object);
        }


        [Test]
        public void Company_Get_ReturnsOk()
        {
            //Arrange

            //Act
            var response = this.companyController.Get();
            var result = response as OkObjectResult;

            //Assert
            Assert.That(result, Is.TypeOf<OkObjectResult>());
        }

        [Test]
        public void Company_Get_ReturnsList()
        {
            //Arrange
            var expected = new List<Company> { new Company { Id = 1, Name = "Test Company", Number = "1234567", VatNumber = "GB 984 7929 44", Address1 = "29 Acacia Road", Address2 = "", Town = "Nuttytown", County = "Dandytown", PostCode = "AB1 2CD" } };
            this.companyServiceMock.Setup(x => x.Get()).Returns(expected);

            //Act
            var response = this.companyController.Get();
            var result = response as OkObjectResult;

            var resultList = (List<Company>)result.Value;

            //Assert
            Assert.AreEqual(expected.Count, resultList.Count);
        }

        [Test]
        public void Company_Get_ReturnsSingle()
        {
            //Arrange
            var expected = new Company { Id = 1, Name = "Test Company", Number = "1234567", VatNumber = "GB 984 7929 44", Address1 = "29 Acacia Road", Address2 = "", Town = "Nuttytown", County = "Dandytown", PostCode = "AB1 2CD" };
            this.companyServiceMock.Setup(x => x.Get(1)).Returns(expected);

            //Act
            var response = this.companyController.Get(1);
            var result = response as OkObjectResult;

            //Assert
            Assert.AreEqual(expected, result.Value);
        }

        [Test]
        public void Company_Post_ReturnsOk()
        {
            //Arrange
            var company = new Company { Id = 1, Name = "Test Company", Number = "1234567", VatNumber = "GB 984 7929 44", Address1 = "29 Acacia Road", Address2 = "", Town = "Nuttytown", County = "Dandytown", PostCode = "AB1 2CD" };

            //Act
            var response = this.companyController.Post(company);
            var result = response as OkObjectResult;

            //Assert
            Assert.That(result, Is.TypeOf<OkObjectResult>());
        }

        [Test]
        public void Company_Put_ReturnsOk()
        {
            //Arrange
            var company = new Company { Id = 1, Name = "Test Company", Number = "1234567", VatNumber = "GB 984 7929 44", Address1 = "29 Acacia Road", Address2 = "", Town = "Nuttytown", County = "Dandytown", PostCode = "AB1 2CD" };

            //Act
            var response = this.companyController.Put(company);
            var result = response as OkObjectResult;

            //Assert
            Assert.That(result, Is.TypeOf<OkObjectResult>());
        }

        [Test]
        public void Company_Delete_ReturnsOk()
        {
            //Arrange

            //Act
            var response = this.companyController.Delete(1);
            var result = response as OkObjectResult;

            //Assert
            Assert.That(result, Is.TypeOf<OkObjectResult>());
        }
    }
}
