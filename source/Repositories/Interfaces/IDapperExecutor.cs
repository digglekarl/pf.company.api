using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace api.Repositories.Interfaces
{
    public interface IDapperExecutor
    {
        IEnumerable<T> Query<T>(IDbConnection connection, string query, object parameters=null);
        T QuerySingle<T>(IDbConnection connection, string query, object parameters);
        int Execute(IDbConnection connection, string query, object parameters);
    }
}
