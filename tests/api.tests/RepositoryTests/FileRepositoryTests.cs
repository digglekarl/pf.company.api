using api.Models;
using api.Repositories;
using api.Repositories.Interfaces;
using Moq;
using NUnit.Framework;
using System;
using System.Data;

namespace api.tests.RepositoryTests
{
    public class FileRepositoryTests
    {
        private FileRepository fileRepository;
        private Mock<IDapperExecutor> dapperExecutorMock;

        [SetUp]
        public void SetUp()
        {
            this.dapperExecutorMock = new Mock<IDapperExecutor>();
            this.fileRepository = new FileRepository(this.dapperExecutorMock.Object);
        }

        [Test]
        public void Create_IsCreated_ReturnsTrue()
        {
            //Arrange
            var file = new Models.File { Content = new byte[1], Name = "test.pdf", Size = 1, UploadDate = DateTime.Now, CompanyId = 1 };
            this.dapperExecutorMock.Setup(x => x.Execute(It.IsAny<IDbConnection>(), It.IsAny<string>(), It.IsAny<object>())).Returns(1);

            //Act
            var result = this.fileRepository.Create(file, It.IsAny<string>(), It.IsAny<object>());

            //Assert
            Assert.True(result);
        }

        [Test]
        public void Create_IsNotCreated_ReturnsFalse()
        {
            //Arrange
            var file = new Models.File { Content = new byte[1], Name = "test.pdf", Size = 1, UploadDate = DateTime.Now, CompanyId = 1 };
            this.dapperExecutorMock.Setup(x => x.Execute(It.IsAny<IDbConnection>(), It.IsAny<string>(), It.IsAny<object>())).Returns(-1);

            //Act
            var result = this.fileRepository.Create(file, It.IsAny<string>(), It.IsAny<object>());

            //Assert
            Assert.False(result);
        }
    }
}
