using CaspianChemichalsWebAPI.Dtos.AboutDtos;
using CaspianChemichalsWebAPI.Enums;

namespace CaspianChemichalsWebAPI.Abstraction.Services
{
    public interface IAboutService
    {
        Task<ICollection<AboutItemDto>> GetAllAsync(int page, int take);
        Task<ICollection<AboutItemDto>> GetAllTranslatedAsync(int page,Language language, int take);
        Task<AboutItemDto> GetAsync(int id);
        Task<AboutItemDto> GetTranslatedAsync(int id,Language language);
        Task CreateAsync(AboutCreateDto aboutDto);
        Task UpdateAsync(AboutUpdateDto aboutDto, int id);
        Task DeleteAsync(int id);
    }
}
