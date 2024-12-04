using CaspianChemichalsWebAPI.Dtos.AboutDtos;
using CaspianChemichalsWebAPI.Dtos.AboutTranslatedDtos;
using CaspianChemichalsWebAPI.Enums;

namespace CaspianChemichalsWebAPI.Abstraction.Services
{
    public interface IAboutTranslateService
    {
        Task<ICollection<AboutTranslateItemDto>> GetAllAsync(int page, int take);
        Task<AboutTranslateItemDto> GetAsync(int id);
        Task CreateAsync(AboutTranslateCreateDto aboutDto);
        Task UpdateAsync(AboutTranslateUpdateDto aboutDto, int id);
        Task DeleteAsync(int id);
    }
}
