using api.Models;
using api.Repositories.Interfaces;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Repositories
{
    public class InvoiceRepository : BaseRepository, IInvoiceRepository
    {
        public InvoiceRepository(IDapperExecutor dapperExecutor) : base(dapperExecutor)
        {
        }

        public List<Invoice> Get()
        {
            using (var connection = new NpgsqlConnection(connectionString))
            {
                return this.dapperExecutor.Query<Invoice>(connection, Queries.Invoices.GetAll).ToList();
            }
        }

        public Invoice Get(long id)
        {
            using (var connection = new NpgsqlConnection(connectionString))
            {
                return this.dapperExecutor.QuerySingle<Invoice>(connection, Queries.Invoices.Get, new { ID = id });
            }
        }

        public bool Create(Invoice invoice)
        {
            using (var connection = new NpgsqlConnection(connectionString))
            {
                return this.dapperExecutor.Execute(connection, Queries.Invoices.Create, new { INVOICEDATE = invoice.InvoiceDate, RATE = invoice.Rate, TOTALDAYS = invoice.TotalDays, REFERENCE = invoice.Reference }) > 0;
            }
        }

        public bool Update(Invoice invoice)
        {
            using (var connection = new NpgsqlConnection(connectionString))
            {
                return this.dapperExecutor.Execute(connection, Queries.Invoices.Update, new { ID = invoice.Id, INVOICEDATE = invoice.InvoiceDate, RATE = invoice.Rate, TOTALDAYS = invoice.TotalDays, REFERENCE = invoice.Reference }) > 0;
            }
        }

        public bool Delete(long id)
        {
            using (var connection = new NpgsqlConnection(connectionString))
            {
                return this.dapperExecutor.Execute(connection, Queries.Invoices.Delete, new { ID = id }) > 0;
            }
        }
    }
}
