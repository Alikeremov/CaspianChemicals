namespace CaspianChemichalsWebAPI.Dtos.OurPartnerDtos
{
    public record OurPartnerItemDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? WebsiteLink { get; set; }
        public string Logo { get; set; } = null!;
    }
}
