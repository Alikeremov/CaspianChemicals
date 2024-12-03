namespace CaspianChemichalsWebAPI.Dtos.SliderDtos
{
    public record SliderItemDto
    {
        public int Id { get; set; }
        public int Order { get; set; }
        public string Tittle { get; set; } = null!;
        public string Subtittle { get; set; } = null!;
    }
}
