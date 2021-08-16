using api.Services.Interfaces;
using api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Repositories.Interfaces;

namespace api.Services
{
    public class DividendService : IDividendService
    {
        private IBaseRepository baseRepository;

        public DividendService(IBaseRepository baseRepository)
        {
            this.baseRepository = baseRepository;
        }

        public List<Dividend> Get()
        {
            return this.baseRepository.Get<Dividend>(Repositories.Queries.Dividends.GetAll);
        }

        public Dividend Get(long id)
        {
            return this.baseRepository.Get<Dividend>(id, Repositories.Queries.Dividends.GetSingle, new { ID = id });
        }

        public bool Create(Dividend dividend)
        {
            return this.baseRepository.Create(dividend, Repositories.Queries.Dividends.Create, new { AMOUNT = dividend.Amount, REFERENCE = dividend.Reference, REQUESTEDDATE = dividend.RequestedDate });
        }

        public bool Update(Dividend dividend)
        {
            return this.baseRepository.Update(dividend, Repositories.Queries.Dividends.Update, new { ID = dividend.Id, AMOUNT = dividend.Amount, REFERENCE = dividend.Reference, REQUESTEDDATE = dividend.RequestedDate });
        }

        public bool Delete(long id)
        {
            return this.baseRepository.Delete(id, Repositories.Queries.Dividends.Delete, new { ID = id });
        }
    }
}
