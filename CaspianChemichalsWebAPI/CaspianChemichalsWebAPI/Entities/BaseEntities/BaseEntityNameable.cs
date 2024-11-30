namespace CaspianChemichalsWebAPI.Entities.BaseEntities
{
    public abstract class BaseEntityNameable:BaseEntity
    {
        public string Name { get; set; } = null!;
    }
}
