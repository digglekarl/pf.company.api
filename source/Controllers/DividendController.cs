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
    public class DividendController : ControllerBase
    {
        private IDividendService dividendService;

        public DividendController(IDividendService dividendService)
        {
            this.dividendService = dividendService;
        }

        // GET: api/<DividendController>
        [HttpGet]
        public IActionResult Get()
        {
            var response = this.dividendService.Get();

            return Ok(response);
        }

        // GET api/<DividendController>/1
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var response = this.dividendService.Get(id);

            return Ok(response);
        }

        // POST api/<DividendController>
        [HttpPost]
        public IActionResult Post([FromBody] Dividend dividend)
        {
           var response = this.dividendService.Create(dividend);

            return Ok(response);
        }

        // PUT api/<DividendController>/1
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Dividend dividend)
        {
            var response = this.dividendService.Update(dividend);
            
            return Ok(response);
        }

        // DELETE api/<DividendController>/1
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            bool response = this.dividendService.Delete(id);

            return Ok(response);
        }
    }
}
