using api.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Repositories
{
    public class ExpenseRepository : BaseRepository
    {
        public ExpenseRepository(IDapperExecutor dapperExecutor) : base(dapperExecutor)
        {

        }
    }
}
