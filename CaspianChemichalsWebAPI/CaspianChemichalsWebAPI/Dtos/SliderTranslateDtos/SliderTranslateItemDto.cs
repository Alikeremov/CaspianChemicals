using CaspianChemichalsWebAPI.Enums;

namespace CaspianChemichalsWebAPI.Dtos.SliderTranslateDtos
{
    public record SliderTranslateItemDto
    {
        public int Id { get; set; }
        public string Tittle { get; set; } = null!;
        public string Subtittle { get; set; } = null!;
        public Language Language { get; set; }
        public int? SliderId { get; set; }
    }
}
