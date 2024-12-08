using AutoMapper;
using CaspianChemichalsWebAPI.Abstraction.Services;
using CaspianChemichalsWebAPI.Dtos.AutenticationDtos;
using CaspianChemichalsWebAPI.Dtos.TokenDtos;
using CaspianChemichalsWebAPI.Entities;
using Microsoft.AspNetCore.Identity;

namespace CaspianChemichalsWebAPI.Implementations.Services
{
    public class AutenticationService : IAutenticationService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IMapper _mapper;
        private readonly IJwtTokenService _jwtTokenService;
        private readonly IHttpContextAccessor _accessor;
        private readonly RoleManager<AppUser> _roleManager;

        public AutenticationService(UserManager<AppUser> userManager,IMapper mapper,IJwtTokenService jwtTokenService,IHttpContextAccessor accessor,
            RoleManager<AppUser> roleManager)
        {
                _userManager = userManager;
                _mapper = mapper;
                _jwtTokenService = jwtTokenService;
                _accessor = accessor;
                _roleManager = roleManager;
        }
        public Task CreateRoleAsync()
        {
            throw new NotImplementedException();
        }

        public Task<AppUserGetDto> GetCurrentUserAsync()
        {
            throw new NotImplementedException();
        }

        public Task<string> GetUserRoleAsync(string id)
        {
            throw new NotImplementedException();
        }

        public bool IsUserCurrent()
        {
            throw new NotImplementedException();
        }

        public Task<TokenResponseDto> Login(LoginDto loginDto)
        {
            throw new NotImplementedException();
        }

        public Task Register(RegisterDto registerDto)
        {
            throw new NotImplementedException();
        }
    }
}
