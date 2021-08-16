using api.Models;
using api.Repositories.Interfaces;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Repositories
{
    public class InvoiceRepository : BaseRepository
    {
        public InvoiceRepository(IDapperExecutor dapperExecutor) : base(dapperExecutor)
        {
        }
    }
}
