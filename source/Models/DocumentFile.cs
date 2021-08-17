using api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    public class DocumentFile
    {
        public Document Document { get; set; }
        public File File { get; set; }
    }
}
