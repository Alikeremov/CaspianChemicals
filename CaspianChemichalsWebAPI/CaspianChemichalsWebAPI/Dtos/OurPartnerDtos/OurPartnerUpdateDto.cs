namespace CaspianChemichalsWebAPI.Dtos.OurPartnerDtos
{
    public record OurPartnerUpdateDto
    {
        public string Name { get; set; } = null!;
        public string? WebsiteLink { get; set; }
        public string? ExistLogo { get; set; }
        public IFormFile? NewLogo { get; set; } 
    }
}
