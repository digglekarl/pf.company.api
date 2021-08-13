using api.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Repositories
{
    public class BaseRepository
    {
        public const string connectionString = "User ID=postgres;Password=Password1.;Host=localhost;Port=5432;Database=postgres;";

        public IDapperExecutor dapperExecutor;

        public BaseRepository(IDapperExecutor dapperExecutor)
        {
            this.dapperExecutor = dapperExecutor;
        }
    }
}
