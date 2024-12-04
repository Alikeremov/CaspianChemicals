using CaspianChemichalsWebAPI.Dtos.SliderDtos;
using CaspianChemichalsWebAPI.Enums;

namespace CaspianChemichalsWebAPI.Abstraction.Services
{
    public interface ISliderService
    {
        Task<ICollection<SliderItemDto>> GetAllAsync(int page, int take);
        Task<ICollection<SliderItemDto>> GetAllTranslatedAsync(int page, Language language, int take);
        Task<SliderItemDto> GetAsync(int id);
        Task<SliderItemDto> GetTranslatedAsync(int id);
        Task CreateAsync(SliderCreateDto sliderDto);
        Task UpdateAsync(SliderUpdateDto sliderDto, int id);
        Task DeleteAsync(int id);
    }
}
