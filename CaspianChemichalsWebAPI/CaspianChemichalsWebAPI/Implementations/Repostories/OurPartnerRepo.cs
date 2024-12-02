using CaspianChemichalsWebAPI.Abstraction.Repostories;
using CaspianChemichalsWebAPI.Contexts;
using CaspianChemichalsWebAPI.Entities;
using CaspianChemichalsWebAPI.Implementations.Repostories.Generic;

namespace CaspianChemichalsWebAPI.Implementations.Repostories
{
    public class OurPartnerRepo : Repository<OurPartner>, IOurPartnerRepo
    {
        public OurPartnerRepo(AppDbContext context) : base(context)
        {
        }
    }
}
