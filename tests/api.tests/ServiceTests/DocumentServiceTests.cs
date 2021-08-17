using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using api.Models;
using api.Repositories;
using api.Repositories.Interfaces;
using api.Services;
using Moq;
using NUnit.Framework;

namespace api.tests.ServiceTests
{
    public class DocumentServiceTests
    {
        private DocumentService documentService;
        private Mock<IBaseRepository> baseRepositoryMock;

        [SetUp]
        public void SetUp()
        {
            this.baseRepositoryMock = new Mock<IBaseRepository>();
            this.documentService = new DocumentService(this.baseRepositoryMock.Object);
        }

        [Test]
        public void Get_NoDocumentsExist_ReturnsEmptyList()
        {
            //Arrange
            var expected = new List<Document>();
            this.baseRepositoryMock.Setup(x => x.Get<Document>(It.IsAny<string>())).Returns(expected);

            //Act
            var result = this.documentService.Get();

            //Assert
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void Get_DocumentsExist_ReturnsList()
        {
            //Arrange
            var expected = new List<Document> { new Document { Id = 1, DocumentName = "Test Document", RenewalDate = DateTime.Now, CompanyId = 1, FileId = 1, DocumentTypeId = 1 } };
            this.baseRepositoryMock.Setup(x => x.Get<Document>(It.IsAny<string>())).Returns(expected);

            //Act
            var result = this.documentService.Get();

            //Assert
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void Get_DocumentsById_ReturnsDocument()
        {
            //Arrange
            var expected = new Document { Id = 1, DocumentName = "Test Document", RenewalDate = DateTime.Now, CompanyId = 1, FileId = 1, DocumentTypeId = 1 };
            this.baseRepositoryMock.Setup(x => x.Get<Document>(It.IsAny<long>(), It.IsAny<string>(), It.IsAny<object>())).Returns(expected);

            //Act
            var result = this.documentService.Get(1);

            //Assert
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void Create_IsCreated_ReturnsTrue()
        {
            //Arrange
            var document = new Document { DocumentName = "Test Document", RenewalDate = DateTime.Now, CompanyId = 1, FileId = 1, DocumentTypeId = 1 };
            this.baseRepositoryMock.Setup(x => x.Create(It.IsAny<Document>(), It.IsAny<string>(), It.IsAny<object>())).Returns(true);

            //Act
            var result = this.documentService.Create(document);

            //Assert
            Assert.True(result);
        }

        [Test]
        public void Create_IsNotCreated_ReturnsFalse()
        {
            //Arrange
            var document = new Document { DocumentName = "Test Document", RenewalDate = DateTime.Now, CompanyId = 1, FileId = 1, DocumentTypeId = 1 };
            this.baseRepositoryMock.Setup(x => x.Create(It.IsAny<Document>(), It.IsAny<string>(), It.IsAny<object>())).Returns(false);

            //Act
            var result = this.documentService.Create(document);

            //Assert
            Assert.False(result);
        }

        [Test]
        public void Update_IsUpdated_ReturnsTrue()
        {
            //Arrange
            var document = new Document { Id = 1, DocumentName = "Test Document", RenewalDate = DateTime.Now, CompanyId = 1, FileId = 1, DocumentTypeId = 1 };
            this.baseRepositoryMock.Setup(x => x.Update(It.IsAny<Document>(), It.IsAny<string>(), It.IsAny<object>())).Returns(true);

            //Act
            var result = this.documentService.Update(document);

            //Assert
            Assert.True(result);
        }

        [Test]
        public void Update_IsNotUpdated_ReturnsFalse()
        {
            //Arrange
            var document = new Document { Id = 1, DocumentName = "Test Document", RenewalDate = DateTime.Now, CompanyId = 1, FileId = 1, DocumentTypeId = 1 };
            this.baseRepositoryMock.Setup(x => x.Update(It.IsAny<Document>(), It.IsAny<string>(), It.IsAny<object>())).Returns(false);

            //Act
            var result = this.documentService.Update(document);

            //Assert
            Assert.False(result);
        }

        [Test]
        public void Delete_IsDeleted_ReturnsTrue()
        {
            //Arrange
            this.baseRepositoryMock.Setup(x => x.Delete(It.IsAny<long>(), It.IsAny<string>(), It.IsAny<object>())).Returns(true);

            //Act
            var result = this.documentService.Delete(It.IsAny<long>());

            //Assert
            Assert.IsTrue(result);
        }

        [Test]
        public void Delete_IsNotDeleted_ReturnsFalse()
        {
            //Arrange
            this.baseRepositoryMock.Setup(x => x.Delete(It.IsAny<long>(), It.IsAny<string>(), It.IsAny<object>())).Returns(false);

            //Act
            var result = this.documentService.Delete(It.IsAny<long>());

            //Assert
            Assert.False(result);
        }
    }
}
