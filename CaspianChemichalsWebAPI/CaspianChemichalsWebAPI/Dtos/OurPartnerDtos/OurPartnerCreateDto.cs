namespace CaspianChemichalsWebAPI.Dtos.OurPartnerDtos
{
    public record OurPartnerCreateDto
    {
        public string Name { get; set; } = null!;
        public string? WebsiteLink { get; set; }
        public IFormFile Logo { get; set; } = null!;
    }
}
