using CaspianChemichalsWebAPI.Entities.BaseEntities;

namespace CaspianChemichalsWebAPI.Entities
{
    public class OurPartners:BaseEntityNameable
    {
        public string Logo { get; set; } = null!;
        public string? WebsiteLink { get; set; }

    }
}
