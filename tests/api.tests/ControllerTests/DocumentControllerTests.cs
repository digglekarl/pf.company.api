using api.Controllers;
using api.Models;
using api.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;

namespace api.tests.ControllerTests
{
    public class DocumentControllerTests
    {
        private DocumentController documentController;
        private Mock<IDocumentService> documentServiceMock;
        private Mock<IHttpContextAccessor> httpContextAccessorMock;
        private Mock<ITokenService> tokenServiceMock;

        [SetUp]
        public void SetUp()
        {
            this.documentServiceMock = new Mock<IDocumentService>();
            this.httpContextAccessorMock = new Mock<IHttpContextAccessor>();
            this.tokenServiceMock = new Mock<ITokenService>();
            this.documentController = new DocumentController(this.documentServiceMock.Object, this.httpContextAccessorMock.Object, this.tokenServiceMock.Object);
        }

        [Test]
        public void Document_Get_ReturnsEmptyList()
        {
            //Arrange
            var expected = new List<DocumentFile>();
            this.documentServiceMock.Setup(x => x.Get()).Returns(expected);

            //Act
            var response = this.documentController.Get();
            var result = response as OkObjectResult;

            var resultList = (List<DocumentFile>)result.Value;

            //Assert
            Assert.AreEqual(expected.Count, resultList.Count);
        }

        [Test]
        public void Document_Get_ReturnsList()
        {
            //Arrange
            var expected = new List<DocumentFile> { new DocumentFile { Document = new Document { Id = 1, DocumentName = "Test Document", RenewalDate = DateTime.Now, CompanyId = 1, FileId = 1, DocumentTypeId = 1 }, File = new File { Content = new byte[1], Name = "test.pdf", Size = 1, UploadDate = DateTime.Now, CompanyId = 1 } } };
            this.documentServiceMock.Setup(x => x.Get()).Returns(expected);

            //Act
            var response = this.documentController.Get();
            var result = response as OkObjectResult;

            var resultList = (List<DocumentFile>)result.Value;

            //Assert
            Assert.AreEqual(expected.Count, resultList.Count);
        }

        [Test]
        public void Document_Get_ReturnsSingle()
        {
            //Arrange
            var expected = new DocumentFile { Document = new Document { Id = 1, DocumentName = "Test Document", RenewalDate = DateTime.Now, CompanyId = 1, FileId = 1, DocumentTypeId = 1 }, File = new File { Content = new byte[1], Name = "test.pdf", Size = 1, UploadDate = DateTime.Now, CompanyId = 1 } };
            this.documentServiceMock.Setup(x => x.Get(It.IsAny<long>())).Returns(expected);

            //Act
            var response = this.documentController.Get(It.IsAny<long>());
            var result = response as OkObjectResult;

            //Assert
            Assert.AreEqual(expected, result.Value);
        }

        [Test]
        public void Document_Post_ReturnsOk()
        {
            //Arrange
            var document = new Document { DocumentName = "Test Document", RenewalDate = DateTime.Now, CompanyId = 1, FileId = 1, DocumentTypeId = 1 };
            this.documentServiceMock.Setup(x => x.Create(It.IsAny<Document>())).Returns(true);

            //Act
            var response = this.documentController.Post(document);
            var result = response as OkObjectResult;

            //Assert
            Assert.That(result, Is.TypeOf<OkObjectResult>());
        }

        [Test]
        public void Document_Put_ReturnsOk()
        {
            //Arrange
            var document = new Document { Id = 1, DocumentName = "Test Document", RenewalDate = DateTime.Now, CompanyId = 1, FileId = 1, DocumentTypeId = 1 };
            this.documentServiceMock.Setup(x => x.Update(It.IsAny<Document>())).Returns(true);

            //Act
            var response = this.documentController.Put(document);
            var result = response as OkObjectResult;

            //Assert
            Assert.That(result, Is.TypeOf<OkObjectResult>());
        }

        [Test]
        public void Document_Delete_ReturnsOk()
        {
            this.documentServiceMock.Setup(x => x.Delete(It.IsAny<long>())).Returns(true);

            //Act
            var response = this.documentController.Delete(It.IsAny<long>());
            var result = response as OkObjectResult;

            //Assert
            Assert.That(result, Is.TypeOf<OkObjectResult>());
        }
    }
}
