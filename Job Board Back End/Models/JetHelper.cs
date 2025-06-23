using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Job_Board_Back_End.Interfaces;

namespace Job_Board_Back_End.Models
{
    public class JwtHelper : IJwtHElper
    {
        public string GenerateToken(User user)
        {
            var claims = new[]
            {
            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new Claim(ClaimTypes.Role, user.Role),
        };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("supersecretkey123"));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(claims: claims, expires: DateTime.UtcNow.AddHours(1), signingCredentials: creds);
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
