using api.Controllers;
using api.Services;
using api.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace api.tests.ControllerTests
{
    public class BaseControllerTests 
    {
        private BaseController baseController;
        private Mock<IHttpContextAccessor> httpContextAccessorMock;
        private Mock<ITokenService> tokenServiceMock;

        [SetUp]
        public void Setup()
        {
            this.httpContextAccessorMock = new Mock<IHttpContextAccessor>();
            this.tokenServiceMock = new Mock<ITokenService>();
            this.baseController = new BaseController(this.httpContextAccessorMock.Object, this.tokenServiceMock.Object);
        }

    }
}
