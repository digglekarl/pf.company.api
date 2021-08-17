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
    public class DocumentController : ControllerBase
    {
        private IDocumentService documentService;
        public DocumentController(IDocumentService documentService)
        {
            this.documentService = documentService;
        }

        // GET: api/<DocumentController>
        [HttpGet]
        public IActionResult Get()
        {
            var response = this.documentService.Get();
            return Ok(response);
        }

        // GET api/<DocumentController>/5
        [HttpGet("{id}")]
        public IActionResult Get(long id)
        {
            var response = this.documentService.Get(id);
            return Ok(response);
        }

        // POST api/<DocumentController>
        [HttpPost]
        public IActionResult Post([FromForm] Document document)
        {
            var response = this.documentService.Create(document);
            return Ok(response);
        }

        // PUT api/<DocumentController>/5
        [HttpPut("{id}")]
        public IActionResult Put([FromBody] Document document)
        {
            var response = this.documentService.Update(document);
            return Ok(response);
        }

        // DELETE api/<DocumentController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            var response = this.documentService.Delete(id);
            return Ok(response);
        }

        /*
        public byte[] GetContent()
        {
            var content = new byte[0];
            if (this.DocumentFile.Length > 0)
            {
                using (var stream = this.DocumentFile.OpenReadStream())
                {
                    content = new byte[this.DocumentFile.Length];
                    stream.Read(content, 0, (int)this.DocumentFile.Length);
                }
            }
            return content;
        }
        */
    }
}
