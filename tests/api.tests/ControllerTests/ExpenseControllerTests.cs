using api.Controllers;
using api.Models;
using api.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace api.tests.ControllerTests
{
    public class ExpenseControllerTests
    {
        private ExpenseController expenseController;
        private Mock<IExpenseService> expenseServiceMock;
        private Mock<IHttpContextAccessor> httpContextAccessorMock;
        private Mock<ITokenService> tokenServiceMock;

        [SetUp]
        public void SetUp()
        {
            this.expenseServiceMock = new Mock<IExpenseService>();

            this.httpContextAccessorMock = new Mock<IHttpContextAccessor>();
            this.tokenServiceMock = new Mock<ITokenService>();
            this.expenseController = new ExpenseController(this.expenseServiceMock.Object, this.httpContextAccessorMock.Object, this.tokenServiceMock.Object);
        }
        
        [Test]
        public void Expense_Get_ReturnsOk()
        {
            //Arrange

            //Act
            var response = this.expenseController.Get();
            var result = response as OkObjectResult;

            //Assert
            Assert.That(result, Is.TypeOf<OkObjectResult>());
        }

        [Test]
        public void Expense_Get_ReturnsList()
        {
            //Arrange
            var expected = new List<Expense> { new Expense { Id = 1, Amount = 100.0M, Description = "Office Supplies", ExpenseDate = DateTime.Now } };
            this.expenseServiceMock.Setup(x => x.Get()).Returns(expected);
            
            //Act
            var response = this.expenseController.Get();
            var result = response as OkObjectResult;

            var resultList = (List<Expense>)result.Value;

            //Assert
            Assert.AreEqual(expected.Count, resultList.Count);
        }

        [Test]
        public void Expense_Get_ReturnsSingle()
        {
            //Arrange
            var expected = new Expense { Id = 1, Amount = 100.0M, Description = "Office Supplies", ExpenseDate = DateTime.Now };
            this.expenseServiceMock.Setup(x => x.Get(It.IsAny<long>())).Returns(expected);

            //Act
            var response = this.expenseController.Get(1);
            var result = response as OkObjectResult;

            //Assert
            Assert.AreEqual(expected, result.Value);
        }

        [Test]
        public void Expense_Post_ReturnsOk()
        {
            //Arrange
            var expense = new Expense { Amount = 100.0M, Description = "Office Supplies", ExpenseDate = DateTime.Now };
            this.expenseServiceMock.Setup(x => x.Create(It.IsAny<Expense>())).Returns(true);

            //Act
            var response = this.expenseController.Post(expense);
            var result = response as OkObjectResult;

            //Assert
            Assert.That(result, Is.TypeOf<OkObjectResult>());
        }

        [Test]
        public void Expense_Put_ReturnsOk()
        {
            //Arrange
            var expense = new Expense { Id = 1, Amount = 100.0M, Description = "Office Supplies", ExpenseDate = DateTime.Now };
            this.expenseServiceMock.Setup(x => x.Update(It.IsAny<Expense>())).Returns(true);

            //Act
            var response = this.expenseController.Put(expense);
            var result = response as OkObjectResult;

            //Assert
            Assert.That(result, Is.TypeOf<OkObjectResult>());
        }

        [Test]
        public void Expense_Delete_ReturnsOk()
        {
            //Arrange
            this.expenseServiceMock.Setup(x => x.Delete(It.IsAny<long>())).Returns(true);

            //Act
            var response = this.expenseController.Delete(1);
            var result = response as OkObjectResult;

            //Assert
            Assert.That(result, Is.TypeOf<OkObjectResult>());
        }
    }
}
