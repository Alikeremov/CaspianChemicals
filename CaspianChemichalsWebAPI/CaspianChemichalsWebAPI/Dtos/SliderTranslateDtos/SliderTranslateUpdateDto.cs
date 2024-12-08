using CaspianChemichalsWebAPI.Enums;

namespace CaspianChemichalsWebAPI.Dtos.SliderTranslateDtos
{
    public record SliderTranslateUpdateDto
    {
        public string Tittle { get; set; } = null!;
        public string Subtittle { get; set; } = null!;
        public int? SliderId { get; set; }
        public Language Language { get; set; }
    }
}
