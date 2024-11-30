namespace CaspianChemichalsWebAPI.Entities.BaseEntities
{
    public abstract class BaseEntity
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public string CreatedBy { get; set; } = null!;
        public BaseEntity()
        {
            CreatedBy = "Ali.Keremov";
            CreatedAt = DateTime.Now;
        }
    }
}
