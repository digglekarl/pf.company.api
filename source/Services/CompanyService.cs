using api.Models;
using api.Repositories.Interfaces;
using api.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Services
{
    public class CompanyService : ICompanyService
    {
        private IBaseRepository baseRepository;
        public CompanyService(IBaseRepository baseRepository)
        {
            this.baseRepository = baseRepository;
        }

        public List<Company> Get()
        {
            return this.baseRepository.Get<Company>(Repositories.Queries.Companies.GetAll);
        }

        public Company Get(long id)
        {
            return this.baseRepository.Get<Company>(id, Repositories.Queries.Companies.GetSingle, new { ID = id });
        }

        public bool Create(Company company)
        {
            return this.baseRepository.Create(company, Repositories.Queries.Companies.Create, new { NAME = company.Name, NUMBER = company.Number, VATNUMBER = company.VatNumber, ADDRESS1 = company.Address1, ADDRESS2 = company.Address2, TOWN = company.Town, COUNTY = company.County, POSTCODE = company.PostCode });
        }

        public bool Update(Company company)
        {
            return this.baseRepository.Update(company, Repositories.Queries.Companies.Update, new { ID = company.Id, NAME = company.Name, NUMBER = company.Number, VATNUMBER = company.VatNumber, ADDRESS1 = company.Address1, ADDRESS2 = company.Address2, TOWN = company.Town, COUNTY = company.County, POSTCODE = company.PostCode });
        }

        public bool Delete(long id)
        {
            return this.baseRepository.Delete(id, Repositories.Queries.Companies.Delete, new { ID = id });
        }

    }
}
