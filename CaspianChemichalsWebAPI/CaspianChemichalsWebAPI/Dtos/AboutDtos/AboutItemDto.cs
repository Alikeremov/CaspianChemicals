namespace CaspianChemichalsWebAPI.Dtos.AboutDtos
{
    public record AboutItemDto
    {
        public int Id { get; set; }
        public string Tittle { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string Image { get; set; } = null!;
    }
}
