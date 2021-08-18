using api.Models;
using api.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;

namespace api.Services
{
    public class TokenService : ITokenService
    {
        public JwtSecurityToken Decode(Token token)
        {
            try
            {
                var jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
                var jwtToken = jwtSecurityTokenHandler.ReadToken(token.assertion);
                return jwtToken as JwtSecurityToken;
               }
            catch (Exception ex)
            {
                throw new Exception($"Error decoding token. {token.assertion}");
            }
        }
    }
}
