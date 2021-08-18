using api.Models;
using api.Services;
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
    public class UploadController : BaseController
    {
        private IFileService fileService;

        public UploadController(IFileService fileService, IHttpContextAccessor httpContextAccessor, ITokenService tokenService) : base(httpContextAccessor, tokenService)
        {
            this.fileService = fileService;
        }

        // POST api/<UploadController>
        [HttpPost]
        public IActionResult Post([FromForm] UploadFile documentFile)
        {
            var response = this.fileService.Create(documentFile);
            return Ok(response);
        }
    }
}
