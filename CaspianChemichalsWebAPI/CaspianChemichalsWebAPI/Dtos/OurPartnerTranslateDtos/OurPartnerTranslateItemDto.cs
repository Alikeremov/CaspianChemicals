using CaspianChemichalsWebAPI.Enums;

namespace CaspianChemichalsWebAPI.Dtos.OurPartnerTranslateDtos
{
    public record OurPartnerTranslateItemDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public Language Language { get; set; }
        public int? OurPartnerId { get; set; }
    }
}
