using api.Models;
using api.Services;
using api.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace api.Controllers
{
    [Authorize(AuthenticationSchemes = Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerDefaults.AuthenticationScheme)]
    public class BaseController : ControllerBase
    {
        public long CompanyId { get; set; }
        public BaseController(IHttpContextAccessor httpContextAccessor, ITokenService tokenService) 
        {
            try
            {
                var authorization = httpContextAccessor.HttpContext.Request.Headers[HeaderNames.Authorization];

                if (AuthenticationHeaderValue.TryParse(authorization, out var header))
                {
                    var token = new Token
                    {
                        assertion = header.Parameter
                    };

                    var decodedToken = tokenService.Decode(token);
                    this.CompanyId = int.Parse(decodedToken.Claims.FirstOrDefault(claim => claim.Type == "id")?.Value);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to decode Jwt token", ex);
            }
        }
    }
}
