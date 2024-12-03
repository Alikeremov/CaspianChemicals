namespace CaspianChemichalsWebAPI.Dtos.AboutDtos
{
    public record AboutUpdateDto
    {
        public string Tittle { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string? ExistImage { get; set; }
        public IFormFile? NewImage { get; set; } = null!;
    }
}
