using CaspianChemichalsWebAPI.Entities.BaseEntities;

namespace CaspianChemichalsWebAPI.Entities
{
    public class OurPartner:BaseEntityNameable
    {
        public string Logo { get; set; } = null!;
        public string? WebsiteLink { get; set; }
        //Relational properties 
        public ICollection<OurPartnerTranslate> Translates { get; set; }

    }
}
