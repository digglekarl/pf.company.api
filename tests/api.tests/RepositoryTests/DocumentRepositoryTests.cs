using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using api.Models;
using api.Repositories;
using api.Repositories.Interfaces;
using Moq;
using NUnit.Framework;

namespace api.tests.RepositoryTests
{
    public class DocumentRepositoryTests
    {
        private DocumentRepository documentRepository;
        private Mock<IDapperExecutor> dapperExecutorMock;
        [SetUp]
        public void SetUp()
        {
            this.dapperExecutorMock = new Mock<IDapperExecutor>();
            this.documentRepository = new DocumentRepository(this.dapperExecutorMock.Object);
        }

        [Test]
        public void Get_NoDocumentsExist_ReturnsEmptyList()
        {
            //Arrange
            var expected = new List<Document>();
            this.dapperExecutorMock.Setup(x => x.Query<Document>(It.IsAny<IDbConnection>(), It.IsAny<string>(), It.IsAny<object>())).Returns(expected);

            //Act
            var result = this.documentRepository.Get<Document>(It.IsAny<string>());

            //Assert
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void Get_DocumentsExist_ReturnsList()
        {
            var expected = new List<Document> { new Document { Id = 1, DocumentName = "Test Document", RenewalDate = DateTime.Now, CompanyId = 1, FileId = 1, DocumentTypeId = 1 } };
            this.dapperExecutorMock.Setup(x => x.Query<Document>(It.IsAny<IDbConnection>(), It.IsAny<string>(), It.IsAny<object>())).Returns(expected);

            //Act
            var result = this.documentRepository.Get<Document>(It.IsAny<string>());

            //Assert
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void Get_DocumentById_ReturnsDocument()
        {
            var expected = new Document { Id = 1, DocumentName = "Test Document", RenewalDate = DateTime.Now, CompanyId = 1, FileId = 1, DocumentTypeId = 1 } ;
            this.dapperExecutorMock.Setup(x => x.QuerySingle<Document>(It.IsAny<IDbConnection>(), It.IsAny<string>(), It.IsAny<object>())).Returns(expected);

            //Act
            var result = this.documentRepository.Get<Document>(1, It.IsAny<string>(), It.IsAny<object>());

            //Assert
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void Create_IsCreated_ReturnsTrue()
        {
            var document = new Document { DocumentName = "Test Document", RenewalDate = DateTime.Now, CompanyId = 1, FileId = 1, DocumentTypeId = 1 };
            this.dapperExecutorMock.Setup(x => x.Execute(It.IsAny<IDbConnection>(), It.IsAny<string>(), It.IsAny<object>())).Returns(1);

            //Act
            var result = this.documentRepository.Create(document, It.IsAny<string>(), It.IsAny<object>());

            //Assert
            Assert.IsTrue(result);
        }

        [Test]
        public void Create_IsNotCreated_ReturnsFalse()
        {
            var document = new Document { DocumentName = "Test Document", RenewalDate = DateTime.Now, CompanyId = 1, FileId = 1, DocumentTypeId = 1 };
            this.dapperExecutorMock.Setup(x => x.Execute(It.IsAny<IDbConnection>(), It.IsAny<string>(), It.IsAny<object>())).Returns(-1);

            //Act
            var result = this.documentRepository.Create(document, It.IsAny<string>(), It.IsAny<object>());

            //Assert
            Assert.IsFalse(result);
        }

        [Test]
        public void Update_IsUpdated_ReturnsTrue()
        {
            var document = new Document { Id = 1, DocumentName = "Test Document", RenewalDate = DateTime.Now, CompanyId = 1, FileId = 1, DocumentTypeId = 1 };
            this.dapperExecutorMock.Setup(x => x.Execute(It.IsAny<IDbConnection>(), It.IsAny<string>(), It.IsAny<object>())).Returns(1);

            //Act
            var result = this.documentRepository.Update(document, It.IsAny<string>(), It.IsAny<object>());

            //Assert
            Assert.True(result);
        }

        [Test]
        public void Update_IsNotUpdated_ReturnsTrue()
        {
            var document = new Document { Id = 1, DocumentName = "Test Document", RenewalDate = DateTime.Now, CompanyId = 1, FileId = 1, DocumentTypeId = 1 };
            this.dapperExecutorMock.Setup(x => x.Execute(It.IsAny<IDbConnection>(), It.IsAny<string>(), It.IsAny<object>())).Returns(-1);

            //Act
            var result = this.documentRepository.Update(document, It.IsAny<string>(), It.IsAny<object>());

            //Assert
            Assert.False(result);
        }

        [Test]
        public void Delete_IsDeleted_ReturnsTrue()
        {
            this.dapperExecutorMock.Setup(x => x.Execute(It.IsAny<IDbConnection>(), It.IsAny<string>(), It.IsAny<object>())).Returns(1);

            //Act
            var result = this.documentRepository.Delete(It.IsAny<long>(), It.IsAny<string>(), It.IsAny<object>());

            //Assert
            Assert.True(result);
        }

        [Test]
        public void Delete_IsNotDeleted_ReturnsFalse()
        {
            this.dapperExecutorMock.Setup(x => x.Execute(It.IsAny<IDbConnection>(), It.IsAny<string>(), It.IsAny<object>())).Returns(-1);

            //Act
            var result = this.documentRepository.Delete(It.IsAny<long>(), It.IsAny<string>(), It.IsAny<object>());

            //Assert
            Assert.False(result);
        }
    }
}
