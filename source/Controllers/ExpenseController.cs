using api.Models;
using api.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExpenseController : ControllerBase
    {
        private IExpenseService expenseService;

        public ExpenseController(IExpenseService expenseService)
        {
            this.expenseService = expenseService;
        }

        // GET: api/<ExpenseController>
        [HttpGet]
        public IActionResult Get()
        {
            var response = this.expenseService.Get();
            return Ok(response);
        }

        // GET api/<ExpenseController>/5
        [HttpGet("{id}")]
        public IActionResult Get(long id)
        {
            var response = this.expenseService.Get(id);
            return Ok(response);
        }

        // POST api/<ExpenseController>
        [HttpPost]
        public IActionResult Post([FromBody] Expense expense)
        {
            var response = this.expenseService.Create(expense);
            return Ok(response);
        }

        // PUT api/<ExpenseController>/5
        [HttpPut("{id}")]
        public IActionResult Put([FromBody] Expense expense)
        {
            var response = this.expenseService.Update(expense);
            return Ok(response);
        }

        // DELETE api/<ExpenseController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var response = this.expenseService.Delete(id);
            return Ok(response);
        }
    }
}
