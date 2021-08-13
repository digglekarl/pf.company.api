using api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Repositories.Interfaces
{
    public interface IInvoiceRepository
    {
        List<Invoice> Get();
        Invoice Get(long id);
        bool Create(Invoice invoice);
        bool Update(Invoice invoice);
        bool Delete(long id);
    }
}
