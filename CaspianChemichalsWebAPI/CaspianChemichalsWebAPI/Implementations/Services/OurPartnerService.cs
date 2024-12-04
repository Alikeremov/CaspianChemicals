using CaspianChemichalsWebAPI.Abstraction.Services;
using CaspianChemichalsWebAPI.Dtos.OurPartnerDtos;
using CaspianChemichalsWebAPI.Enums;

namespace CaspianChemichalsWebAPI.Implementations.Services
{
    public class OurPartnerService : IOurPartnerService
    {
        public Task CreateAsync(OurPartnerCreateDto ourPartnerDto)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<OurPartnerItemDto>> GetAllAsync(int page, int take)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<OurPartnerItemDto>> GetAllTranslatedAsync(int page, Language language, int take)
        {
            throw new NotImplementedException();
        }

        public Task<OurPartnerItemDto> GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<OurPartnerItemDto> GetTranslatedAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(OurPartnerUpdateDto ourPartnerDto, int id)
        {
            throw new NotImplementedException();
        }
    }
}
