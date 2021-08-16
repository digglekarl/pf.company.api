using api.Models;
using api.Repositories.Interfaces;
using api.Services;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace api.tests.ServiceTests
{
    public class ExpenseServiceTests
    {
        private ExpenseService expenseService;
        private Mock<IBaseRepository> baseRepositoryMock;

        [SetUp]
        public void SetUp()
        {
            this.baseRepositoryMock = new Mock<IBaseRepository>();
            this.expenseService = new ExpenseService(this.baseRepositoryMock.Object);
        }

        [Test]
        public void Get_NoExpenses_ReturnsEmptyList()
        {
            //Arrange
            var expected = new List<Expense>();
            this.baseRepositoryMock.Setup(x => x.Get<Expense>(It.IsAny<string>())).Returns(expected);

            //Act
            var result = this.expenseService.Get();

            //Assert
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void Get_ExpensesExist_ReturnsList()
        {
            //Arrange
            var expected = new List<Expense> { new Expense { Id = 1, Amount = 100.0M, Description = "Office Supplies", ExpenseDate = DateTime.Now } };
            this.baseRepositoryMock.Setup(x => x.Get<Expense>(It.IsAny<string>())).Returns(expected);

            //Act
            var result = this.expenseService.Get();

            //Assert
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void Get_ExpensebyId_ReturnsSingle()
        {
            //Arrange
            var expected = new Expense { Id = 1, Amount = 100.0M, Description = "Office Supplies", ExpenseDate = DateTime.Now };
            this.baseRepositoryMock.Setup(x => x.Get<Expense>(It.IsAny<long>(), It.IsAny<string>(), It.IsAny<object>())).Returns(expected);

            //Act
            var result = this.expenseService.Get(1);

            //Assert
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void Create_IsCreated_ReturnsTrue()
        {
            //Arrange
            var expense = new Expense { Amount = 100.0M, Description = "Office Supplies", ExpenseDate = DateTime.Now };
            this.baseRepositoryMock.Setup(x => x.Create(It.IsAny<Expense>(), It.IsAny<string>(), It.IsAny<object>())).Returns(true);

            //Act
            var result = this.expenseService.Create(expense);

            //Assert
            Assert.IsTrue(result);
        }

        [Test]
        public void Create_IsNotCreated_ReturnsTrue()
        {
            //Arrange
            var expense = new Expense { Amount = 100.0M, Description = "Office Supplies", ExpenseDate = DateTime.Now };
            this.baseRepositoryMock.Setup(x => x.Create(It.IsAny<Expense>(), It.IsAny<string>(), It.IsAny<object>())).Returns(false);

            //Act
            var result = this.expenseService.Create(expense);

            //Assert
            Assert.IsFalse(result);
        }

        [Test]
        public void Update_IsUpdated_ReturnsTrue()
        {
            //Arrange
            var expense = new Expense { Id = 1, Amount = 100.0M, Description = "Office Supplies", ExpenseDate = DateTime.Now };
            this.baseRepositoryMock.Setup(x => x.Update(It.IsAny<Expense>(), It.IsAny<string>(), It.IsAny<object>())).Returns(true);

            //Act
            var result = this.expenseService.Update(expense);

            //Assert
            Assert.IsTrue(result);
        }

        [Test]
        public void Update_IsNotUpdated_ReturnsFalse()
        {
            //Arrange
            var expense = new Expense { Id = 1, Amount = 100.0M, Description = "Office Supplies", ExpenseDate = DateTime.Now };
            this.baseRepositoryMock.Setup(x => x.Update(It.IsAny<Expense>(), It.IsAny<string>(), It.IsAny<object>())).Returns(false);

            //Act
            var result = this.expenseService.Update(expense);

            //Assert
            Assert.IsFalse(result);
        }

        [Test]
        public void Delete_IsDeleted_ReturnsTrue()
        {
            //Arrange
            this.baseRepositoryMock.Setup(x => x.Delete(It.IsAny<long>(), It.IsAny<string>(), It.IsAny<object>())).Returns(true);

            //Act
            var result = this.expenseService.Delete(1);

            //Assert
            Assert.IsTrue(result);
        }

        [Test]
        public void Delete_IsNotDeleted_ReturnsFalse()
        {
            //Arrange
            this.baseRepositoryMock.Setup(x => x.Delete(It.IsAny<long>(), It.IsAny<string>(), It.IsAny<object>())).Returns(false);

            //Act
            var result = this.expenseService.Delete(1);

            //Assert
            Assert.IsFalse(result);
        }
    }
}
