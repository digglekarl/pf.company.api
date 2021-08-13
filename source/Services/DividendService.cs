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
        private IDividendRepository dividendRepository;

        public DividendService(IDividendRepository dividendRepository)
        {
            this.dividendRepository = dividendRepository;
        }

        public List<Dividend> Get()
        {
            var dividends = this.dividendRepository.Get();

            return dividends;
        }

        public Dividend Get(int id)
        {
            var dividend = this.dividendRepository.Get(id);

            return dividend;
        }

        public bool Create(Dividend dividend)
        {
            var result = this.dividendRepository.Create(dividend);
            return result;
        }

        public bool Update(Dividend dividend)
        {
            var result = this.dividendRepository.Update(dividend);
            return result;
        }

        public bool Delete(int id)
        {
            var result = this.dividendRepository.Delete(1);
            return result;
        }

    }
}
