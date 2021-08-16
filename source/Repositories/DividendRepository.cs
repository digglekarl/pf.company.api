using api.Models;
using api.Repositories.Interfaces;
using Dapper;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Repositories
{
    public class DividendRepository : BaseRepository
    {
        public DividendRepository(IDapperExecutor dapperExecutor) : base(dapperExecutor)
        {
        }
    }
}
