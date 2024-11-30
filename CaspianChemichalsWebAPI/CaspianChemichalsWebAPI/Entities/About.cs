using CaspianChemichalsWebAPI.Entities.BaseEntities;

namespace CaspianChemichalsWebAPI.Entities
{
    public class About : BaseEntity
    {
        public string Tittle { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string Image { get; set; } = null!;
    }
}
