using CaspianChemichalsWebAPI.Abstraction.Services;
using CaspianChemichalsWebAPI.Dtos.SliderDtos;
using CaspianChemichalsWebAPI.Enums;

namespace CaspianChemichalsWebAPI.Implementations.Services
{
    public class SliderService : ISliderService
    {
        public Task CreateAsync(SliderCreateDto sliderDto)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<SliderItemDto>> GetAllAsync(int page, int take)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<SliderItemDto>> GetAllTranslatedAsync(int page, Language language, int take)
        {
            throw new NotImplementedException();
        }

        public Task<SliderItemDto> GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<SliderItemDto> GetTranslatedAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(SliderUpdateDto sliderDto, int id)
        {
            throw new NotImplementedException();
        }
    }
}
