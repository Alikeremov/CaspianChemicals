using Microsoft.AspNetCore.Http;

namespace CaspianChemichalsWebAPI.Dtos.AboutDtos
{
    public record AboutCreateDto
    {
        public string Tittle { get; set; } = null!;
        public string Description { get; set; } = null!;
        public IFormFile Image { get; set; } = null!;
    }
}
