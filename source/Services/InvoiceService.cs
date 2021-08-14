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
        private IInvoiceRepository invoiceRepository;

        public InvoiceService(IInvoiceRepository invoiceRepository)
        {
            this.invoiceRepository = invoiceRepository;
        }

        public List<Invoice> Get()
        {
            return this.invoiceRepository.Get();
        }

        public Invoice Get(long id)
        {
            return this.invoiceRepository.Get(id);
        }

        public bool Create(Invoice invoice)
        {
            return this.invoiceRepository.Create(invoice);
        }

        public bool Update(Invoice invoice)
        {
            return this.invoiceRepository.Update(invoice);
        }

        public bool Delete(long id)
        {
            return this.invoiceRepository.Delete(id);
        }
    }
}
