using CaspianChemichalsWebAPI.Abstraction.Repostories;
using CaspianChemichalsWebAPI.Contexts;
using CaspianChemichalsWebAPI.Entities;
using CaspianChemichalsWebAPI.Implementations.Repostories.Generic;

namespace CaspianChemichalsWebAPI.Implementations.Repostories
{
    public class AboutRepo : Repository<About>,IAboutRepo
    {
        public AboutRepo(AppDbContext context) : base(context)
        {
        }
    }
}
