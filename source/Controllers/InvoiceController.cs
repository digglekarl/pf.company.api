using api.Models;
using api.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvoiceController : BaseController
    {
        private IInvoiceService invoiceService;

        public InvoiceController(IInvoiceService invoiceService, IHttpContextAccessor httpContextAccessor, ITokenService tokenService) : base(httpContextAccessor, tokenService)
        {
            this.invoiceService = invoiceService;
        }

        // GET: api/<InvoiceController>
        [HttpGet]
        public IActionResult Get()
        {
            var response = this.invoiceService.Get();
            return Ok(response);
        }

        // GET api/<InvoiceController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var response = this.invoiceService.Get(id);
            return Ok(response);
        }

        // POST api/<InvoiceController>
        [HttpPost]
        public IActionResult Post([FromBody] Invoice invoice)
        {
            var response = this.invoiceService.Create(invoice);
            return Ok(response);
        }

        // PUT api/<InvoiceController>/5
        [HttpPut("{id}")]
        public IActionResult Put([FromBody] Invoice invoice)
        {
            var response = this.invoiceService.Update(invoice);
            return Ok(response);
        }

        // DELETE api/<InvoiceController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var response = this.invoiceService.Delete(id);
            return Ok(response);
        }
    }
}
