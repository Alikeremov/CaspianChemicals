using CaspianChemichalsWebAPI.Abstraction.Services;
using CaspianChemichalsWebAPI.Dtos.TokenDtos;
using CaspianChemichalsWebAPI.Entities;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace CaspianChemichalsWebAPI.Implementations.Services
{
    public class JwtTokenService:IJwtTokenService
    {
        private readonly IConfiguration _configuration;

        public JwtTokenService(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public TokenResponseDto CreateJwtToken(AppUser user, int minutes, List<string> roles)
        {
            ICollection<Claim> userclaims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier,user.Id),
                new Claim(ClaimTypes.Name,user.UserName),
                new Claim(ClaimTypes.GivenName,user.Name),
                new Claim(ClaimTypes.Surname,user.Surname),
                new Claim(ClaimTypes.Email,user.Email),

            };
            foreach (var role in roles)
            {
                userclaims.Add(new Claim(ClaimTypes.Role, role));
            }
            SymmetricSecurityKey securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:SecurityKey"]));
            SigningCredentials credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            JwtSecurityToken token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                notBefore: DateTime.UtcNow,
                expires: DateTime.UtcNow.AddMinutes(minutes),
                claims: userclaims,
                signingCredentials: credentials

                );
            JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();


            return new TokenResponseDto(user.UserName, handler.WriteToken(token), token.ValidTo);
        }
    }
}
