using CaspianChemichalsWebAPI.Dtos.OurPartnerDtos;
using CaspianChemichalsWebAPI.Enums;

namespace CaspianChemichalsWebAPI.Abstraction.Services
{
    public interface IOurPartnerService
    {
        Task<ICollection<OurPartnerItemDto>> GetAllAsync(int page, int take);
        Task<ICollection<OurPartnerItemDto>> GetAllTranslatedAsync(int page, Language language, int take);
        Task<OurPartnerItemDto> GetAsync(int id);
        Task<OurPartnerItemDto> GetTranslatedAsync(int id);
        Task CreateAsync(OurPartnerCreateDto ourPartnerDto);
        Task UpdateAsync(OurPartnerUpdateDto ourPartnerDto, int id);
        Task DeleteAsync(int id);
    }
}
