using api.Models;
using api.Repositories;
using api.Repositories.Interfaces;
using api.Services;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;

namespace api.tests.ServiceTests
{
    public class CompanyServiceTests
    {
        private CompanyService companyService;
        private Mock<IBaseRepository> baseRepositoryMock;

        [SetUp]
        public void SetUp()
        {
            this.baseRepositoryMock = new Mock<IBaseRepository>();
            this.companyService = new CompanyService(this.baseRepositoryMock.Object);
        }

        [Test]
        public void Get_NoCompanies_ReturnsEmptyList()
        {
            //Arrange
            var expected = new List<Company>();
            this.baseRepositoryMock.Setup(x => x.Get<Company>(It.IsAny<string>())).Returns(expected);

            //Act
            var result = this.companyService.Get();

            //Assert
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void Get_CompaniesExist_ReturnsList()
        {
            //Arrange
            var expected = new List<Company> { new Company { Id = 1, Name = "Test Company", Number = "1234567", VatNumber = "GB 984 7929 44", Address1 = "29 Acacia Road", Address2 = "", Town = "Nuttytown", County = "Dandytown", PostCode = "AB1 2CD" } };
            this.baseRepositoryMock.Setup(x => x.Get<Company>(It.IsAny<string>())).Returns(expected);

            //Act
            var result = this.companyService.Get();

            //Assert
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void Get_CompanyById_ReturnsCompany()
        {
            //Arrange
            var expected = new Company { Id = 1, Name = "Test Company", Number = "1234567", VatNumber = "GB 984 7929 44", Address1 = "29 Acacia Road", Address2 = "", Town = "Nuttytown", County = "Dandytown", PostCode = "AB1 2CD" };
            this.baseRepositoryMock.Setup(x => x.Get<Company>(It.IsAny<long>(), It.IsAny<string>(), It.IsAny<object>())).Returns(expected);

            //Act
            var result = this.companyService.Get(1);

            //Assert
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void Create_IsCreated_ReturnsTrue()
        {
            //Arrange
            var company = new Company { Name = "Test Company", Number = "1234567", VatNumber = "GB 984 7929 44", Address1 = "29 Acacia Road", Address2 = "", Town = "Nuttytown", County = "Dandytown", PostCode = "AB1 2CD" };
            this.baseRepositoryMock.Setup(x => x.Create(It.IsAny<Company>(), It.IsAny<string>(), It.IsAny<object>())).Returns(true);

            //Act
            var result = this.companyService.Create(company);

            //Assert
            Assert.IsTrue(result);
        }

        [Test]
        public void Create_IsNotCreated_ReturnsFalse()
        {
            //Arrange
            var company = new Company { Name = "Test Company", Number = "1234567", VatNumber = "GB 984 7929 44", Address1 = "29 Acacia Road", Address2 = "", Town = "Nuttytown", County = "Dandytown", PostCode = "AB1 2CD" };
            this.baseRepositoryMock.Setup(x => x.Create(It.IsAny<Company>(), It.IsAny<string>(), It.IsAny<object>())).Returns(false);

            //Act
            var result = this.companyService.Create(company);

            //Assert
            Assert.IsFalse(result);
        }

        [Test]
        public void Update_IsUpdated_ReturnsTrue()
        {
            //Arrange
            var company = new Company { Id = 1, Name = "Test Company", Number = "1234567", VatNumber = "GB 984 7929 44", Address1 = "29 Acacia Road", Address2 = "", Town = "Nuttytown", County = "Dandytown", PostCode = "AB1 2CD" };
            this.baseRepositoryMock.Setup(x => x.Update(It.IsAny<Company>(), It.IsAny<string>(), It.IsAny<object>())).Returns(true);

            //Act
            var result = this.companyService.Update(company);

            //Assert
            Assert.IsTrue(result);
        }

        [Test]
        public void Update_IsNotUpdated_ReturnsFalse()
        {
            //Arrange
            var company = new Company { Id = 1, Name = "Test Company", Number = "1234567", VatNumber = "GB 984 7929 44", Address1 = "29 Acacia Road", Address2 = "", Town = "Nuttytown", County = "Dandytown", PostCode = "AB1 2CD" };
            this.baseRepositoryMock.Setup(x => x.Update(It.IsAny<Company>(), It.IsAny<string>(), It.IsAny<object>())).Returns(false);

            //Act
            var result = this.companyService.Update(company);

            //Assert
            Assert.IsFalse(result);
        }

        [Test]
        public void Delete_IsDeleted_ReturnsTrue()
        {
            //Arrange
            this.baseRepositoryMock.Setup(x => x.Delete(It.IsAny<long>(), It.IsAny<string>(), It.IsAny<object>())).Returns(true);

            //Act
            var result = this.companyService.Delete(1);

            //Assert
            Assert.IsTrue(result);
        }

        [Test]
        public void Delete_IsNotDeleted_ReturnsFalse()
        {
            //Arrange
            this.baseRepositoryMock.Setup(x => x.Delete(It.IsAny<long>(), It.IsAny<string>(), It.IsAny<object>())).Returns(false);

            //Act
            var result = this.companyService.Delete(1);

            //Assert
            Assert.IsFalse(result);
        }
    }
}
