using api.Models;
using api.Repositories.Interfaces;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Repositories
{
    public class BaseRepository : IBaseRepository
    {
        public const string connectionString = "User ID=postgres;Password=Password1.;Host=localhost;Port=5432;Database=postgres;";

        public IDapperExecutor dapperExecutor;

        public BaseRepository(IDapperExecutor dapperExecutor)
        {
            this.dapperExecutor = dapperExecutor;
            Dapper.DefaultTypeMap.MatchNamesWithUnderscores = true;
        }

        public List<T> Get<T>(string query)
        {
            using (var connection = new NpgsqlConnection(connectionString))
            {
                return this.dapperExecutor.Query<T>(connection, query).ToList();
            }
        }

        public T Get<T>(long id, string query, object parameters)
        {
            using (var connection = new NpgsqlConnection(connectionString))
            {
                return this.dapperExecutor.QuerySingle<T>(connection, query, parameters);
            }
        }

        public bool Create<T>(T data, string query, object parameters)
        {
            using (var connection = new NpgsqlConnection(connectionString))
            {
                return this.dapperExecutor.Execute(connection, query, parameters) > 0;
            }
        }

        public bool Update<T>(T data, string query, object parameters)
        {
            using (var connection = new NpgsqlConnection(connectionString))
            {
                return this.dapperExecutor.Execute(connection, query, parameters) > 0;
            }
        }

        public bool Delete(long id, string query, object parameters)
        {
            using (var connection = new NpgsqlConnection(connectionString))
            {
                return this.dapperExecutor.Execute(connection, query, parameters) > 0;
            }
        }


    }
}
