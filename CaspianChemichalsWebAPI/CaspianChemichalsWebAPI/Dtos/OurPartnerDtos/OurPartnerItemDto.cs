namespace CaspianChemichalsWebAPI.Dtos.OurPartnerDtos
{
    public record OurPartnerItemDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? WebsiteLink { get; set; }
        public IFormFile Logo { get; set; } = null!;
    }
}
