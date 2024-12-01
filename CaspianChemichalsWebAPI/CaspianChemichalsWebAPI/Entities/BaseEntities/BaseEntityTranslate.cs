using CaspianChemichalsWebAPI.Enums;

namespace CaspianChemichalsWebAPI.Entities.BaseEntities
{
    public abstract class BaseEntityTranslate:BaseEntity
    {
        public Language Language { get; set; }
    }
}
