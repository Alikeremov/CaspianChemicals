using AutoMapper;
using CaspianChemichalsWebAPI.Dtos.SliderTranslateDtos;
using CaspianChemichalsWebAPI.Entities;

namespace CaspianChemichalsWebAPI.MappingProfiles
{
    public class SliderTranslateProfile:Profile
    {
        public SliderTranslateProfile()
        {
            CreateMap<SliderTranslate, SliderTranslateItemDto>();
            CreateMap<SliderTranslateCreateDto, SliderTranslate>();
            CreateMap<SliderTranslate, SliderTranslateUpdateDto>();
        }
    }
}
