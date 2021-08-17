using api.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Repositories
{
    public class DocumentRepository : BaseRepository
    {
        public DocumentRepository(IDapperExecutor dapperExecutor) : base(dapperExecutor)
        {
        }
    }
}
