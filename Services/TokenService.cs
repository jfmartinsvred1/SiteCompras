using Microsoft.IdentityModel.Tokens;
using SiteCompras.Models;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace SiteCompras.Services
{
    public  class TokenService
    {
        public  string GenerateToken(User user, List<string> roles)
        {
            var tokenHander = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes("sdfdsfsd87fsd7fsd6fdfsdfdsfsdf34");
            var claims = new List<Claim>();
            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }
            claims.Add(new Claim(ClaimTypes.Name, user.UserName));
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHander.CreateToken(tokenDescriptor);

            return tokenHander.WriteToken(token);
        }
    }
}
