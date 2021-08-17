using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    public class Dividend
    {
        public long Id { get; set; }
        public decimal Amount { get; set; }
        public decimal RatePerShare => Amount / 100M;
        public DateTime RequestedDate { get; set; }
        public string Reference { get; set; }
        public long CompanyId { get; set; }
    }
}
