using CaspianChemichalsWebAPI.Entities.BaseEntities;

namespace CaspianChemichalsWebAPI.Entities
{
    public class AboutTranslate:BaseEntityTranslate
    {
        public string Tittle { get; set; } = null!;
        public string Description { get; set; } = null!;
        //Relational properties
        public int AboutId { get; set; }
        public About  About { get; set; }
    }
}
