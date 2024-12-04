using CaspianChemichalsWebAPI.Dtos.OurPartnerTranslateDtos;
using CaspianChemichalsWebAPI.Enums;

namespace CaspianChemichalsWebAPI.Abstraction.Services
{
    public interface IOurPartnerTranslateService
    {
        Task<ICollection<OurPartnerTranslateItemDto>> GetAllAsync(int page, int take);
        Task<OurPartnerTranslateItemDto> GetAsync(int id);
        Task CreateAsync(OurPartnerTranslateCreateDto ourPartnerTranslateDto);
        Task UpdateAsync(OurPartnerTranslateUpdateDto ourPartnerTranslateDto, int id);
        Task DeleteAsync(int id);
    }
}
