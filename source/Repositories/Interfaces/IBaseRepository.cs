using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Repositories.Interfaces
{
    public interface IBaseRepository
    {
        List<T> Get<T>(string query);
        T Get<T>(long id, string query, object parameters);
        bool Create<T>(T data, string query, object parameters);
        bool Update<T>(T data, string query, object parameters);
        bool Delete(long id, string query, object parameters);
    }
}
