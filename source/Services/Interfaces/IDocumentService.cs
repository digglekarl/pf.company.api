using api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Services.Interfaces
{
    public interface IDocumentService
    {
        List<DocumentFile> Get();
        DocumentFile Get(long id);
        bool Create(Document dividend);
        bool Update(Document dividend);
        bool Delete(long id);
    }
}
