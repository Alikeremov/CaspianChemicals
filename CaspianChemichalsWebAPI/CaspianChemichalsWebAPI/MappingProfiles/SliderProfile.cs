using AutoMapper;
using CaspianChemichalsWebAPI.Dtos.SliderDtos;
using CaspianChemichalsWebAPI.Entities;

namespace CaspianChemichalsWebAPI.MappingProfiles
{
    public class SliderProfile:Profile
    {
        public SliderProfile()
        {
            CreateMap<Slider, SliderItemDto>();
            CreateMap<SliderCreateDto, Slider>();
            CreateMap<Slider, SliderUpdateDto>();
        }
    }
}
