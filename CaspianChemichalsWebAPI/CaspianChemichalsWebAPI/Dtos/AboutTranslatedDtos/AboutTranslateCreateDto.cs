namespace CaspianChemichalsWebAPI.Dtos.AboutTranslatedDtos
{
    public record AboutTranslateCreateDto
    {
        public string Tittle { get; set; } = null!;
        public string Description { get; set; } = null!;
        public int AboutId { get; set; }
    }
}
