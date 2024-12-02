using CaspianChemichalsWebAPI.Abstraction.Repostories;
using CaspianChemichalsWebAPI.Contexts;
using CaspianChemichalsWebAPI.Entities;
using CaspianChemichalsWebAPI.Implementations.Repostories.Generic;

namespace CaspianChemichalsWebAPI.Implementations.Repostories
{
    public class AboutTranslateRepo : TranslatedRepo<AboutTranslate>,IAboutTranslateRepo
    {
        public AboutTranslateRepo(AppDbContext context) : base(context)
        {
        }
    }
}
