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
    public class DividendRepository : BaseRepository, IDividendRepository
    {
        public DividendRepository(IDapperExecutor dapperExecutor) : base(dapperExecutor)
        {
        }

        public List<Dividend> Get()
        {
            using (var connection = new NpgsqlConnection(connectionString))
            {
                return this.dapperExecutor.Query<Dividend>(connection, Queries.Dividends.GetAll).ToList();
            }
        }

        public Dividend Get(long id)
        {
            using (var connection = new NpgsqlConnection(connectionString))
            {
                return this.dapperExecutor.QuerySingle<Dividend>(connection, Queries.Dividends.GetSingle, new { ID = id });
            }
        }

        public bool Create(Dividend dividend)
        {
            using(var connection = new NpgsqlConnection(connectionString))
            {
                return this.dapperExecutor.Execute(connection, Queries.Dividends.Create, new { AMOUNT = dividend.Amount, REFERENCE = dividend.Reference, REQUESTEDDATE = dividend.RequestedDate }) > 0;
            }
        }

        public bool Update(Dividend dividend)
        {
            using (var connection = new NpgsqlConnection(connectionString))
            {
                return this.dapperExecutor.Execute(connection, Queries.Dividends.Update, new { ID = dividend.Id, AMOUNT = dividend.Amount, REFERENCE = dividend.Reference, REQUESTEDDATE = dividend.RequestedDate }) > 0;
            }
        }

        public bool Delete(long id)
        {
            using (var connection = new NpgsqlConnection(connectionString))
            {
                return this.dapperExecutor.Execute(connection, Queries.Dividends.Delete, new { ID = id }) > 0;
            }
        }
    }
}
