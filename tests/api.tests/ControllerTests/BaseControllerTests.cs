using api.Controllers;
using api.Models;
using api.Services;
using api.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
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

            var httpContext = new DefaultHttpContext();
            httpContext.Request.Headers["Authorization"] = "Bearer";

            httpContextAccessorMock
              .SetupGet(accessor => accessor.HttpContext)
              .Returns(httpContext);

            var jwtToken = new System.IdentityModel.Tokens.Jwt.JwtSecurityToken
            {
            };

            jwtToken.Claims.ToList().Add(new Claim("id", "1"));

            this.tokenServiceMock.Setup(x => x.Decode(It.IsAny<Token>())).Returns(jwtToken);

            this.baseController = new BaseController(this.httpContextAccessorMock.Object, this.tokenServiceMock.Object);
        }


    }
}
