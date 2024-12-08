namespace CaspianChemichalsWebAPI.Dtos.SliderDtos
{
    public record SliderCreateDto
    {
        public int Order { get; set; }
        public string Tittle { get; set; } = null!;
        public string Subtittle { get; set; } = null!;
        public IFormFile Image { get; set; } = null!;
    }
}
