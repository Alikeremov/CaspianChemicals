using CaspianChemichalsWebAPI.Enums;

namespace CaspianChemichalsWebAPI.Dtos.OurPartnerTranslateDtos
{
    public record OurPartnerTranslateUpdateDto
    {
        public string Name { get; set; } = null!;
        public Language Language { get; set; }
        public int OurPartnerId { get; set; }
    }
}
