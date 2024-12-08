using CaspianChemichalsWebAPI.Dtos.AutenticationDtos;
using CaspianChemichalsWebAPI.Dtos.TokenDtos;

namespace CaspianChemichalsWebAPI.Abstraction.Services
{
    public interface IAutenticationService
    {
        Task Register(RegisterDto registerDto);
        Task<TokenResponseDto> Login(LoginDto loginDto);
        bool IsUserCurrent();
        Task<AppUserGetDto> GetCurrentUserAsync();
        Task<string> GetUserRoleAsync(string id);
        Task CreateRoleAsync();
    }
}
