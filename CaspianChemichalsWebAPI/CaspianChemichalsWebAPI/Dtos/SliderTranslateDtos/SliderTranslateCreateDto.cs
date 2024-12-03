namespace CaspianChemichalsWebAPI.Dtos.SliderTranslateDtos
{
    public record class SliderTranslateCreateDto
    {
        public string Tittle { get; set; } = null!;
        public string Subtittle { get; set; } = null!;
        public int SliderId { get; set; }
    }
}
