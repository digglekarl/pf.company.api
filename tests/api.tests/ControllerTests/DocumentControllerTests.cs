using api.Controllers;
using api.Models;
using api.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace api.tests.ControllerTests
{
    public class DocumentControllerTests
    {
        private DocumentController documentController;
        private Mock<IDocumentService> documentServiceMock;

        [SetUp]
        public void SetUp()
        {
            this.documentServiceMock = new Mock<IDocumentService>();
            this.documentController = new DocumentController(this.documentServiceMock.Object);
        }

        [Test]
        public void Document_Get_ReturnsEmptyList()
        {
            //Arrange
            var expected = new List<Document>();
            this.documentServiceMock.Setup(x => x.Get()).Returns(expected);

            //Act
            var response = this.documentController.Get();
            var result = response as OkObjectResult;

            var resultList = (List<Document>)result.Value;

            //Assert
            Assert.AreEqual(expected.Count, resultList.Count);
        }

        [Test]
        public void Document_Get_ReturnsList()
        {
            //Arrange
            var expected = new List<Document> { new Document { Id = 1, DocumentName = "Test Document", RenewalDate = DateTime.Now, CompanyId = 1, FileId = 1, DocumentTypeId = 1 } };
            this.documentServiceMock.Setup(x => x.Get()).Returns(expected);

            //Act
            var response = this.documentController.Get();
            var result = response as OkObjectResult;

            var resultList = (List<Document>)result.Value;

            //Assert
            Assert.AreEqual(expected.Count, resultList.Count);
        }

        [Test]
        public void Document_Get_ReturnsSingle()
        {
            //Arrange
            var expected = new Document { Id = 1, DocumentName = "Test Document", RenewalDate = DateTime.Now, CompanyId = 1, FileId = 1, DocumentTypeId = 1 };
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
