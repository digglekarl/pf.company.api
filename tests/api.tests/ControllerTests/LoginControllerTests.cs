using api.Controllers;
using api.Models;
using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace api.tests.ControllerTests
{
    public class LoginControllerTests
    {
        private LoginController loginController;

        [SetUp]
        public void SetUp()
        {
            this.loginController = new LoginController();
        }

        [Test]
        public void Login_IsAuthenticated_ReturnsOk()
        {
            //Arrange
            var credentials = new Credentials { Username = "user", Password = "Password1" };

            //Act
            var response = this.loginController.Login(credentials);
            var result = response as OkObjectResult;

            //Assert

            Assert.That(result, Is.TypeOf<OkObjectResult>());
        }
    }
}
