using AutoMapper;
using CaspianChemichalsWebAPI.Dtos.OurPartnerDtos;
using CaspianChemichalsWebAPI.Dtos.OurPartnerTranslateDtos;
using CaspianChemichalsWebAPI.Entities;

namespace CaspianChemichalsWebAPI.MappingProfiles
{
    public class OurPartnerTranslateProfile:Profile
    {
        public OurPartnerTranslateProfile()
        {
            CreateMap<OurPartnerTranslate, OurPartnerTranslateItemDto>();
            CreateMap<OurPartnerTranslateCreateDto, OurPartnerTranslate>();
            CreateMap<OurPartnerTranslate, OurPartnerTranslateUpdateDto>();
        }
    }
}
