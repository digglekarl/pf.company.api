using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    public class Expense
    {
        public long Id { get; set; }
        public DateTime ExpenseDate { get; set; }
        public string Description { get; set; }
        public decimal Amount { get; set; }
    }
}
