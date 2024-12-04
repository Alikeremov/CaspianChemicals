using CaspianChemichalsWebAPI.Abstraction.Services;
using CaspianChemichalsWebAPI.Dtos.OurPartnerTranslateDtos;
using CaspianChemichalsWebAPI.Enums;

namespace CaspianChemichalsWebAPI.Implementations.Services
{
    public class OurPartnerTranslateService : IOurPartnerTranslateService
    {
        public Task CreateAsync(OurPartnerTranslateCreateDto ourPartnerTranslateDto)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<OurPartnerTranslateItemDto>> GetAllAsync(int page, int take)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<OurPartnerTranslateItemDto>> GetAllTranslatedAsync(int page, Language language, int take)
        {
            throw new NotImplementedException();
        }

        public Task<OurPartnerTranslateItemDto> GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<OurPartnerTranslateItemDto> GetTranslatedAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(OurPartnerTranslateUpdateDto ourPartnerTranslateDto, int id)
        {
            throw new NotImplementedException();
        }
    }
}
