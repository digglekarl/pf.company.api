using api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Services.Interfaces
{
    public interface IDividendService
    {
        List<Dividend> Get();
        Dividend Get(int id);
        bool Create(Dividend dividend);
        bool Update(Dividend dividend);
        bool Delete(int id);
    }
}
