using api.Models;
using api.Repositories.Interfaces;
using api.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Services
{
    public class InvoiceService : IInvoiceService
    {
        private IBaseRepository baseRepository;

        public InvoiceService(IBaseRepository baseRepository)
        {
            this.baseRepository = baseRepository;
        }

        public List<Invoice> Get()
        {
            return this.baseRepository.Get<Invoice>(Repositories.Queries.Invoices.GetAll);
        }

        public Invoice Get(long id)
        {
            return this.baseRepository.Get<Invoice>(id, Repositories.Queries.Invoices.GetSingle, new { ID = id });
        }

        public bool Create(Invoice invoice)
        {
            return this.baseRepository.Create(invoice, Repositories.Queries.Invoices.Create, new { INVOICEDATE = invoice.InvoiceDate, RATE = invoice.Rate, TOTALDAYS = invoice.TotalDays, REFERENCE = invoice.Reference, COMPANYID = invoice.CompanyId } );
        }

        public bool Update(Invoice invoice)
        {
            return this.baseRepository.Update<Invoice>(invoice, Repositories.Queries.Invoices.Update, new { ID = invoice.Id, INVOICEDATE = invoice.InvoiceDate, RATE = invoice.Rate, TOTALDAYS = invoice.TotalDays, REFERENCE = invoice.Reference, COMPANYID = invoice.CompanyId } );
        }

        public bool Delete(long id)
        {
            return this.baseRepository.Delete(id, Repositories.Queries.Invoices.Delete, new { ID = id });
        }
    }
}
