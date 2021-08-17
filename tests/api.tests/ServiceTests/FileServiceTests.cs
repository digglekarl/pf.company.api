using api.Models;
using api.Repositories.Interfaces;
using api.Services;
using Microsoft.AspNetCore.Http;
using Moq;
using NUnit.Framework;
using System.IO;

namespace api.tests.ServiceTests
{
    public class FileServiceTests
    {
        private FileService fileService;
        private Mock<IBaseRepository> fileRepositoryMock;
        private Mock<IFormFile> formFileMock;

        [SetUp]
        public void SetUp()
        {
            this.fileRepositoryMock = new Mock<IBaseRepository>();
            this.fileService = new FileService(this.fileRepositoryMock.Object);

            this.formFileMock = new Mock<IFormFile>();

            var content = "Test Document";
            var fileName = "test.pdf";
            var ms = new MemoryStream();
            var writer = new StreamWriter(ms);
            writer.Write(content);
            writer.Flush();
            ms.Position = 0;
            this.formFileMock.Setup(_ => _.OpenReadStream()).Returns(ms);
            this.formFileMock.Setup(_ => _.FileName).Returns(fileName);
            this.formFileMock.Setup(_ => _.Length).Returns(ms.Length);
        }

        [Test]
        public void Create_IsCreated_ReturnsTrue()
        {
            //Arrange
            var uploadFile = new UploadFile
            {
                File = this.formFileMock.Object
            };

            this.fileRepositoryMock.Setup(x => x.Create(It.IsAny<Models.File>(), It.IsAny<string>(), It.IsAny<object>())).Returns(true);

            //Act
            var result = this.fileService.Create(uploadFile);

            //Assert
            Assert.True(result);
        }

        [Test]
        public void Create_IsNotCreated_ReturnsFalse()
        {
            //Arrange
            var uploadFile = new UploadFile
            {
                File = this.formFileMock.Object
            };

            this.fileRepositoryMock.Setup(x => x.Create(It.IsAny<Models.File>(), It.IsAny<string>(), It.IsAny<object>())).Returns(false);

            //Act
            var result = this.fileService.Create(uploadFile);

            //Assert
            Assert.False(result);
        }
    }
}
