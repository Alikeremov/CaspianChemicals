using Microsoft.AspNetCore.Identity;

namespace CaspianChemichalsWebAPI.Entities
{
    public class AppUser:IdentityUser
    {
        public string Name { get; set; } = null!;
        public string Surname { get; set; } = null!;
    }
}
