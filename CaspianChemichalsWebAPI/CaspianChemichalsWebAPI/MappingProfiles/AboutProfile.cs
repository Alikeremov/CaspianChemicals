using AutoMapper;
using CaspianChemichalsWebAPI.Dtos.AboutDtos;
using CaspianChemichalsWebAPI.Entities;

namespace CaspianChemichalsWebAPI.MappingProfiles
{
    public class AboutProfile:Profile
    {
        public AboutProfile()
        {
            CreateMap<About, AboutItemDto>();
            CreateMap<AboutCreateDto, About>();
            CreateMap<About, AboutUpdateDto>().ReverseMap();
        }
    }
}
