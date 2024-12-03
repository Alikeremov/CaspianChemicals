namespace CaspianChemichalsWebAPI.Dtos.AboutTranslatedDtos
{
    public record AboutTranslateItemDto
    {
        public int Id { get; set; }
        public string Tittle { get; set; } = null!;
        public string Description { get; set; } = null!;
        public int? AboutId { get; set; }
    }
}
