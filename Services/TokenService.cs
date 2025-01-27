using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using AluraControleUsuarioAPI.Models;

namespace AluraControleUsuarioAPI.Services
{
    public class TokenService
    {

        private IConfiguration _configuration;

        public TokenService(IConfiguration configuration)
        {
            this._configuration = configuration;            
        }
        public string GenerateToken(User user)
        {
            Claim[] claims = new Claim[]
            {
                new Claim("username", user.UserName),
                new Claim("id", user.Id),
                new Claim(ClaimTypes.DateOfBirth, user.DateBirth.ToString()),
                new Claim("loginTimestamp", DateTime.UtcNow.ToString())
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["SymmetricSecurityKey"]));

            var signingCredentials = 
                new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken
                (
                expires: DateTime.Now.AddMinutes(30),
                claims: claims,
                signingCredentials: signingCredentials
                );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}