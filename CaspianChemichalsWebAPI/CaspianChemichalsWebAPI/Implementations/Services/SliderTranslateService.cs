using CaspianChemichalsWebAPI.Abstraction.Services;
using CaspianChemichalsWebAPI.Dtos.SliderTranslateDtos;
using CaspianChemichalsWebAPI.Enums;

namespace CaspianChemichalsWebAPI.Implementations.Services
{
    public class SliderTranslateService : ISliderTranslateService
    {
        public Task CreateAsync(SliderTranslateCreateDto sliderTranslateDto)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<SliderTranslateItemDto>> GetAllAsync(int page, int take)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<SliderTranslateItemDto>> GetAllTranslatedAsync(int page, Language language, int take)
        {
            throw new NotImplementedException();
        }

        public Task<SliderTranslateItemDto> GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<SliderTranslateItemDto> GetTranslatedAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(SliderTranslateUpdateDto sliderTranslateDto, int id)
        {
            throw new NotImplementedException();
        }
    }
}
