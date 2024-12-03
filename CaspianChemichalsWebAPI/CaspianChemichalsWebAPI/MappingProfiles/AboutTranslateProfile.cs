using AutoMapper;
using CaspianChemichalsWebAPI.Dtos.AboutDtos;
using CaspianChemichalsWebAPI.Dtos.AboutTranslatedDtos;
using CaspianChemichalsWebAPI.Entities;

namespace CaspianChemichalsWebAPI.MappingProfiles
{
    public class AboutTranslateProfile:Profile
    {
        public AboutTranslateProfile()
        {
            CreateMap<AboutTranslate, AboutTranslateItemDto>();
            CreateMap<AboutTranslateCreateDto, AboutTranslate>();
            CreateMap<AboutTranslate, AboutTranslateUpdateDto>().ReverseMap();
        }
    }
}
