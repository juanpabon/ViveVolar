using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using ViveVolar.Abstractions;

namespace ViveVolar.Services
{
    public class TokenHandlerService : ITokenHandlerService
    {
        private readonly JwtConfig _jwtConfig;
        public TokenHandlerService(IOptionsMonitor<JwtConfig> optionsMonitor)
        {
            _jwtConfig = optionsMonitor.CurrentValue;
        }
        public string GenerateJwtToken(ITokenParametersModels pars)
        {
            var jwtTokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_jwtConfig.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim("Id",pars.Id.ToString()),
                    new Claim(JwtRegisteredClaimNames.Sub,pars.Login)
                    //,new Claim(JwtRegisteredClaimNames.Email,pars.UserName)
                }),
                Expires = DateTime.Now.AddHours(6),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha512Signature)
            };
            var token = jwtTokenHandler.CreateToken(tokenDescriptor);
            var jwtToken = jwtTokenHandler.WriteToken(token);
            return jwtToken;
        }
    }
}
