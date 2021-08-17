using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    public class Document
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public long Size { get; set; }
        public byte[] Content { get; set; }
        public DateTime? RenewalDate { get; set; }
        public long CompanyId { get; set; }
    }
}
