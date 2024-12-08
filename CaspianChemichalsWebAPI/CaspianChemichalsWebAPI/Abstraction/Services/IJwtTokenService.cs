using CaspianChemichalsWebAPI.Dtos.TokenDtos;
using CaspianChemichalsWebAPI.Entities;

namespace CaspianChemichalsWebAPI.Abstraction.Services
{
    public interface IJwtTokenService
    {
        TokenResponseDto CreateJwtToken(AppUser user, int minutes, List<string> roles);
    }
}
