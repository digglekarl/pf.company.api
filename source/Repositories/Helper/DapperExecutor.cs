using api.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using Dapper;

namespace api.Repositories.Helper
{
    public class DapperExecutor : IDapperExecutor
    {
        public IEnumerable<T> Query<T>(IDbConnection connection, string query, object parameters=null)
        {
            return connection.Query<T>(query, parameters);
        }

        public T QuerySingle<T>(IDbConnection connection, string query, object parameters)
        {
            return connection.QuerySingle<T>(query, parameters);
        }

        public int Execute(IDbConnection connection, string query, object parameters)
        {
            return connection.Execute(query, parameters);
        }

    }
}
