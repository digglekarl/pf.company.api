using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    public class Document
    {
        public long Id { get; set; }
        public string DocumentName { get; set; }
        public DateTime? RenewalDate { get; set; }
        public long CompanyId { get; set; }
        public long FileId { get; set; }
        public long DocumentTypeId { get; set; }
    }
}
