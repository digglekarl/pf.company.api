using api.Models;
using api.Repositories;
using api.Repositories.Interfaces;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace api.tests.RepositoryTests
{
    public class ExpensesRepositoryTests
    {
        private ExpenseRepository expenseRepository;
        private Mock<IDapperExecutor> dapperExecutorMock;

        [SetUp]
        public void SetUp()
        {
            this.dapperExecutorMock = new Mock<IDapperExecutor>() { DefaultValue = DefaultValue.Mock };
            this.expenseRepository = new ExpenseRepository(this.dapperExecutorMock.Object);
        }

        [Test]
        public void Get_NoExpenses_ReturnsEmptyList()
        {
            //Arrange
            var expected = new List<Expense>();
            this.dapperExecutorMock.Setup(x => x.Query<Expense>(It.IsAny<IDbConnection>(), It.IsAny<string>(), It.IsAny<object>())).Returns(expected);

            //Act
            var result = this.expenseRepository.Get<Invoice>(It.IsAny<string>());

            //Assert
            Assert.AreEqual(result, expected);
        }

        [Test]
        public void Get_Expenses_ReturnsList()
        {
            //Arrange
            var expected = new List<Expense> { new Expense { Id = 1, Amount = 100.0M, Description = "Office Supplies", ExpenseDate = DateTime.Now } };
            this.dapperExecutorMock.Setup(x => x.Query<Expense>(It.IsAny<IDbConnection>(), It.IsAny<string>(), It.IsAny<object>())).Returns(expected);

            //Act
            var result = this.expenseRepository.Get<Expense>(It.IsAny<string>());

            //Assert
            Assert.AreEqual(result, expected);
        }

        [Test]
        public void Get_ExpenseById_ReturnsSingle()
        {
            //Arrange
            var expected = new Expense { Id = 1, Amount = 100.0M, Description = "Office Supplies", ExpenseDate = DateTime.Now };
            this.dapperExecutorMock.Setup(x => x.QuerySingle<Expense>(It.IsAny<IDbConnection>(), It.IsAny<string>(), It.IsAny<object>())).Returns(expected);

            //Act
            var result = this.expenseRepository.Get<Expense>(1, It.IsAny<string>(), new { ID = 1 });

            //Assert
            Assert.AreEqual(result, expected);
        }

        [Test]
        public void Create_IsCreated_ReturnsTrue()
        {
            //Arrange
            var expense = new Expense { Amount = 100.0M, Description = "Office Supplies", ExpenseDate = DateTime.Now };
            this.dapperExecutorMock.Setup(x => x.Execute(It.IsAny<IDbConnection>(), It.IsAny<string>(), It.IsAny<object>())).Returns(1);

            //Act
            var result = this.expenseRepository.Create(expense, It.IsAny<string>(), new { AMOUNT = expense.Amount, DESCRIPTION = expense.Description, EXPENSEDATE = expense.ExpenseDate });

            //Assert
            Assert.IsTrue(result);
        }

        [Test]
        public void Create_IsNotCreated_ReturnsTrue()
        {
            //Arrange
            var expense = new Expense { Amount = 100.0M, Description = "Office Supplies", ExpenseDate = DateTime.Now };
            this.dapperExecutorMock.Setup(x => x.Execute(It.IsAny<IDbConnection>(), It.IsAny<string>(), It.IsAny<object>())).Returns(-1);

            //Act
            var result = this.expenseRepository.Create(expense, It.IsAny<string>(), new { AMOUNT = expense.Amount, DESCRIPTION = expense.Description, EXPENSEDATE = expense.ExpenseDate });

            //Assert
            Assert.IsFalse(result);
        }

        [Test]
        public void Update_IsUpdated_ReturnsTrue()
        {
            //Arrange
            var expense = new Expense { Id = 1, Amount = 100.0M, Description = "Office Supplies", ExpenseDate = DateTime.Now };
            this.dapperExecutorMock.Setup(x => x.Execute(It.IsAny<IDbConnection>(), It.IsAny<string>(), It.IsAny<object>())).Returns(1);

            //Act
            var result = this.expenseRepository.Update(expense, It.IsAny<string>(), new { ID = expense.Id, AMOUNT = expense.Amount, DESCRIPTION = expense.Description, EXPENSEDATE = expense.ExpenseDate });

            //Assert
            Assert.IsTrue(result);
        }

        [Test]
        public void Update_IsNotUpdated_ReturnsFalse()
        {
            //Arrange
            var expense = new Expense { Id = 1, Amount = 100.0M, Description = "Office Supplies", ExpenseDate = DateTime.Now };
            this.dapperExecutorMock.Setup(x => x.Execute(It.IsAny<IDbConnection>(), It.IsAny<string>(), It.IsAny<object>())).Returns(-1);

            //Act
            var result = this.expenseRepository.Update(expense, It.IsAny<string>(), new { ID = expense.Id, AMOUNT = expense.Amount, DESCRIPTION = expense.Description, EXPENSEDATE = expense.ExpenseDate });

            //Assert
            Assert.IsFalse(result);
        }

        [Test]
        public void Delete_IsDeleted_ReturnsTrue()
        {
            //Arrange
            this.dapperExecutorMock.Setup(x => x.Execute(It.IsAny<IDbConnection>(), It.IsAny<string>(), It.IsAny<object>())).Returns(1);

            //Act
            var result = this.expenseRepository.Delete(1, It.IsAny<string>(), new { ID = 1 });

            //Assert
            Assert.IsTrue(result);
        }

        [Test]
        public void Delete_IsNotDeleted_ReturnsFalse()
        {
            //Arrange
            this.dapperExecutorMock.Setup(x => x.Execute(It.IsAny<IDbConnection>(), It.IsAny<string>(), It.IsAny<object>())).Returns(-1);

            //Act
            var result = this.expenseRepository.Delete(1, It.IsAny<string>(), new { ID = 1 });

            //Assert
            Assert.IsFalse(result);
        }
    }
}
