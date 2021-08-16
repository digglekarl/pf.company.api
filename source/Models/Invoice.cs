using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    public class Invoice
    {
        public long Id { get; set; }
        public decimal Rate { get; set; }
        public int TotalDays { get; set; }
        public DateTime InvoiceDate { get; set; }
        public string Reference { get; set; }

        public decimal Amount => Rate * TotalDays;
        public decimal Vat => Amount * 0.2M;
        public decimal TotalAmount => Amount + Vat;

    }
}
