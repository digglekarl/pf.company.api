using api.Models;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;

namespace api.Services.Interfaces
{
    public interface ITokenService
    {
        JwtSecurityToken Decode(Token token);
    }
}
