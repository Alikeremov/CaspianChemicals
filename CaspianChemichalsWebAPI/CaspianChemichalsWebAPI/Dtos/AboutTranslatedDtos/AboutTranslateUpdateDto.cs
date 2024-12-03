namespace CaspianChemichalsWebAPI.Dtos.AboutTranslatedDtos
{
    public record AboutTranslateUpdateDto
    {
        public string Tittle { get; set; } = null!;
        public string Description { get; set; } = null!;
        public int AboutId { get; set; }
    }
}
