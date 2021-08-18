using api.Controllers;
using api.Models;
using api.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;

namespace api.tests.ControllerTests
{
    public class UploadControllerTests
    {
        private UploadController uploadController;
        private Mock<IFileService> fileServiceMock;
        private Mock<IHttpContextAccessor> httpContextAccessorMock;
        private Mock<ITokenService> tokenServiceMock;

        [SetUp]
        public void SetUp()
        {
            this.fileServiceMock = new Mock<IFileService>();

            this.httpContextAccessorMock = new Mock<IHttpContextAccessor>();
            this.tokenServiceMock = new Mock<ITokenService>();
            this.uploadController = new UploadController(this.fileServiceMock.Object, this.httpContextAccessorMock.Object, this.tokenServiceMock.Object);
        }

        [Test]
        public void Upload_Post_ReturnsOk()
        {
            //Arrange
            this.fileServiceMock.Setup(x => x.Create(It.IsAny<UploadFile>())).Returns(true);

            //Act
            var response = this.uploadController.Post(It.IsAny<UploadFile>());
            var result = response as OkObjectResult;

            //Assert
            Assert.That(result, Is.TypeOf<OkObjectResult>());
        }
    }
}
