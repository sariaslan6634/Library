using Library.Application.Common.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Library.Infrastructure.Services
{
    public class TokenService(IConfiguration _config) : ITokenService
    {
        public string GenerateToken(Guid Id, string email, List<string> roles)
        {
            var secretKey = _config["JwtSettings:SecretKey"];
            var issuer = _config["JwtSettings:Issuer"];
            var audience = _config["JwtSettings:Audience"];
            var expiration = int.Parse(_config["JwtSettings:ExpirationMinutes"]);

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
            var credentails = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier,Id.ToString()),
                new Claim(ClaimTypes.Email,email),
            };

            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }

            var token = new JwtSecurityToken(
                issuer : issuer,
                audience : audience,
                claims : claims,
                expires: DateTime.UtcNow.AddMinutes(expiration),
                signingCredentials : credentails
                );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
