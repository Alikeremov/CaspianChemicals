using AutoMapper;
using CaspianChemichalsWebAPI.Dtos.OurPartnerDtos;
using CaspianChemichalsWebAPI.Entities;

namespace CaspianChemichalsWebAPI.MappingProfiles
{
    public class OurPartnerProfile:Profile
    {
        public OurPartnerProfile()
        {
            CreateMap<OurPartner,OurPartnerItemDto>();
            CreateMap<OurPartnerCreateDto, OurPartner>();
            CreateMap<OurPartner, OurPartnerUpdateDto>();
        }
    }
}
