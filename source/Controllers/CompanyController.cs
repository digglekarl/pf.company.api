using api.Models;
using api.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
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
    [Authorize]
    public class CompanyController : ControllerBase
    {
        private ICompanyService companyService;
        public CompanyController(ICompanyService companyService, IHttpContextAccessor httpContextAccessor, ITokenService tokenService) 
        {
            this.companyService = companyService;
        }

        // GET: api/<CompanyController>
        [HttpGet]
        public IActionResult Get()
        {
            var response = this.companyService.Get();
            return Ok(response);
        }

        // GET api/<CompanyController>/5
        [HttpGet("{id}")]
        public IActionResult Get(long id)
        {
            var response = this.companyService.Get(id);
            return Ok(response);
        }

        // POST api/<CompanyController>
        [HttpPost]
        public IActionResult Post([FromBody] Company company)
        {
            var response = this.companyService.Create(company);
            return Ok(response);
        }

        // PUT api/<CompanyController>/5
        [HttpPut("{id}")]
        public IActionResult Put([FromBody] Company company)
        {
            var response = this.companyService.Update(company);
            return Ok(response);
        }

        // DELETE api/<CompanyController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            var response = this.companyService.Delete(id);
            return Ok(response);
        }
    }
}
