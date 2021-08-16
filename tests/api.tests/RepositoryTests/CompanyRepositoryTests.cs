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
    public class CompanyRepositoryTests
    {
        private CompanyRepository companyRepository;
        private Mock<IDapperExecutor> dapperExecutorMock;

        [SetUp]
        public void SetUp()
        {
            this.dapperExecutorMock = new Mock<IDapperExecutor>();
            this.companyRepository = new CompanyRepository(this.dapperExecutorMock.Object);
        }

        [Test]
        public void Get_NoCompanies_ReturnsEmptyList()
        {
            //Arrange
            var expected = new List<Company>();
            this.dapperExecutorMock.Setup(x => x.Query<Company>(It.IsAny<IDbConnection>(), It.IsAny<string>(), It.IsAny<object>())).Returns(expected);

            //Act
            var result = this.companyRepository.Get<Company>(It.IsAny<string>());

            //Assert
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void Get_CompaniesExist_ReturnsList()
        {
            //Arrange
            var expected = new List<Company> { new Company { Id = 1, Name = "Test Company", Number = "1234567", VatNumber = "GB 984 7929 44", Address1 = "29 Acacia Road", Address2 = "", Town = "Nuttytown", County = "Dandytown", PostCode = "AB1 2CD" } } ;
            this.dapperExecutorMock.Setup(x => x.Query<Company>(It.IsAny<IDbConnection>(), It.IsAny<string>(), It.IsAny<object>())).Returns(expected);

            //Act
            var result = this.companyRepository.Get<Company>(It.IsAny<string>());

            //Assert
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void Get_CompanyById_ReturnsCompany()
        {
            //Arrange
            var expected = new Company { Id = 1, Name = "Test Company", Number = "1234567", VatNumber = "GB 984 7929 44", Address1 = "29 Acacia Road", Address2 = "", Town = "Nuttytown", County = "Dandytown", PostCode = "AB1 2CD" };
            this.dapperExecutorMock.Setup(x => x.QuerySingle<Company>(It.IsAny<IDbConnection>(), It.IsAny<string>(), It.IsAny<object>())).Returns(expected);

            //Act
            var result = this.companyRepository.Get<Company>(It.IsAny<long>(), It.IsAny<string>(), It.IsAny<object>());

            //Assert
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void Create_IsCreated_ReturnsTrue()
        {
            //Arrange
            var company = new Company { Name = "Test Company", Number = "1234567", VatNumber = "GB 984 7929 44", Address1 = "29 Acacia Road", Address2 = "", Town = "Nuttytown", County = "Dandytown", PostCode = "AB1 2CD" };
            this.dapperExecutorMock.Setup(x => x.Execute(It.IsAny<IDbConnection>(), It.IsAny<string>(), It.IsAny<object>())).Returns(1);

            //Act
            var result = this.companyRepository.Create(company, It.IsAny<string>(), It.IsAny<object>());

            //Assert
            Assert.IsTrue(result);
        }

        [Test]
        public void Create_IsNotCreated_ReturnsFalse()
        {
            //Arrange
            var company = new Company { Name = "Test Company", Number = "1234567", VatNumber = "GB 984 7929 44", Address1 = "29 Acacia Road", Address2 = "", Town = "Nuttytown", County = "Dandytown", PostCode = "AB1 2CD" };
            this.dapperExecutorMock.Setup(x => x.Execute(It.IsAny<IDbConnection>(), It.IsAny<string>(), It.IsAny<object>())).Returns(-1);

            //Act
            var result = this.companyRepository.Create(company, It.IsAny<string>(), It.IsAny<object>());

            //Assert
            Assert.IsFalse(result);
        }

        [Test]
        public void Update_IsUpdated_ReturnsTrue()
        {
            //Arrange
            var company = new Company { Id = 1, Name = "Test Company", Number = "1234567", VatNumber = "GB 984 7929 44", Address1 = "29 Acacia Road", Address2 = "", Town = "Nuttytown", County = "Dandytown", PostCode = "AB1 2CD" };
            this.dapperExecutorMock.Setup(x => x.Execute(It.IsAny<IDbConnection>(), It.IsAny<string>(), It.IsAny<object>())).Returns(1);

            //Act
            var result = this.companyRepository.Update(company, It.IsAny<string>(), It.IsAny<object>());

            //Assert
            Assert.IsTrue(result);
        }

        [Test]
        public void Update_IsNotUpdated_ReturnsFalse()
        {
            //Arrange
            var company = new Company { Id = 1, Name = "Test Company", Number = "1234567", VatNumber = "GB 984 7929 44", Address1 = "29 Acacia Road", Address2 = "", Town = "Nuttytown", County = "Dandytown", PostCode = "AB1 2CD" };
            this.dapperExecutorMock.Setup(x => x.Execute(It.IsAny<IDbConnection>(), It.IsAny<string>(), It.IsAny<object>())).Returns(-1);

            //Act
            var result = this.companyRepository.Update(company, It.IsAny<string>(), It.IsAny<object>());

            //Assert
            Assert.IsFalse(result);
        }

        [Test]
        public void Delete_IsDeleted_ReturnsTrue()
        {
            //Arrange
            this.dapperExecutorMock.Setup(x => x.Execute(It.IsAny<IDbConnection>(), It.IsAny<string>(), It.IsAny<object>())).Returns(1);

            //Act
            var result = this.companyRepository.Delete(It.IsAny<long>(), It.IsAny<string>(), It.IsAny<object>());

            //Assert
            Assert.IsTrue(result);
        }

        [Test]
        public void Delete_IsNotDeleted_ReturnsFalse()
        {
            //Arrange
            this.dapperExecutorMock.Setup(x => x.Execute(It.IsAny<IDbConnection>(), It.IsAny<string>(), It.IsAny<object>())).Returns(-1);

            //Act
            var result = this.companyRepository.Delete(It.IsAny<long>(), It.IsAny<string>(), It.IsAny<object>());

            //Assert
            Assert.IsFalse(result);
        }
    }
}
