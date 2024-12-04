using CaspianChemichalsWebAPI.Dtos.SliderTranslateDtos;
using CaspianChemichalsWebAPI.Enums;

namespace CaspianChemichalsWebAPI.Abstraction.Services
{
    public interface ISliderTranslateService
    {
        Task<ICollection<SliderTranslateItemDto>> GetAllAsync(int page, int take);
        Task<SliderTranslateItemDto> GetAsync(int id);
        Task CreateAsync(SliderTranslateCreateDto sliderTranslateDto);
        Task UpdateAsync(SliderTranslateUpdateDto sliderTranslateDto, int id);
        Task DeleteAsync(int id);
    }
}
