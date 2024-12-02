using CaspianChemichalsWebAPI.Abstraction.Repostories;
using CaspianChemichalsWebAPI.Contexts;
using CaspianChemichalsWebAPI.Entities;
using CaspianChemichalsWebAPI.Implementations.Repostories.Generic;

namespace CaspianChemichalsWebAPI.Implementations.Repostories
{
    public class OurPartnerTranslateRepo : TranslatedRepo<OurPartnerTranslate>,IOurPartnerTranslateRepo
    {
        public OurPartnerTranslateRepo(AppDbContext context) : base(context)
        {
        }
    }
}
