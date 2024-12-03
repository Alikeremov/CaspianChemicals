namespace CaspianChemichalsWebAPI.Dtos.SliderTranslateDtos
{
    public record SliderTranslateItemDto
    {
        public int Id { get; set; }
        public string Tittle { get; set; } = null!;
        public string Subtittle { get; set; } = null!;
        public int? SliderId { get; set; }
    }
}
