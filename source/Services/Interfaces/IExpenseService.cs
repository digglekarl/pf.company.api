using api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Services.Interfaces
{
    public interface IExpenseService
    {
        List<Expense> Get();
        Expense Get(long id);
        bool Create(Expense expense);
        bool Update(Expense expense);
        bool Delete(long id);
    }
}
