namespace CaspianChemichalsWebAPI.Entities.BaseEntities
{
    public abstract class BaseEntityTranslateNameable:BaseEntityTranslate
    {
        public string Name { get; set; } = null!;
    }
}
