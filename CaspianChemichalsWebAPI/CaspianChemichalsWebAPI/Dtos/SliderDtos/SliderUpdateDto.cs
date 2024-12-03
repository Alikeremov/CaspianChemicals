namespace CaspianChemichalsWebAPI.Dtos.SliderDtos
{
    public record SliderUpdateDto
    {
        public int Order { get; set; }
        public string Tittle { get; set; } = null!;
        public string Subtittle { get; set; } = null!;
    }
}
