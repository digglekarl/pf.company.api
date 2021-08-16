using api.Models;
using api.Repositories.Interfaces;
using api.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Services
{
    public class ExpenseService : IExpenseService
    {
        private IBaseRepository baseRepository;

        public ExpenseService(IBaseRepository baseRepository)
        {
            this.baseRepository = baseRepository;
        }

        public List<Expense> Get()
        {
            return this.baseRepository.Get<Expense>(Repositories.Queries.Expenses.GetAll);
        }

        public Expense Get(long id)
        {
            return this.baseRepository.Get<Expense>(id, Repositories.Queries.Expenses.GetSingle, new { ID = id });
        }

        public bool Create(Expense expense)
        {
            return this.baseRepository.Create(expense, Repositories.Queries.Expenses.Create, new { AMOUNT = expense.Amount, DESCRIPTION = expense.Description, EXPENSEDATE = expense.ExpenseDate });
        }
        public bool Update(Expense expense)
        {
            return this.baseRepository.Update(expense, Repositories.Queries.Expenses.Update, new { ID = expense.Id, AMOUNT = expense.Amount, DESCRIPTION = expense.Description, EXPENSEDATE = expense.ExpenseDate });
        }

        public bool Delete(long id)
        {
            return this.baseRepository.Delete(id, Repositories.Queries.Expenses.Delete, new { ID = id });
        }

    }
}
