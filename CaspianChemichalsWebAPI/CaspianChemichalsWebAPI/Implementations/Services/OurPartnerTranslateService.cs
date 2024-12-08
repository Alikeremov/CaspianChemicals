using AutoMapper;
using CaspianChemichalsWebAPI.Abstraction.Repostories;
using CaspianChemichalsWebAPI.Abstraction.Services;
using CaspianChemichalsWebAPI.Dtos.OurPartnerTranslateDtos;
using CaspianChemichalsWebAPI.Entities;
using CaspianChemichalsWebAPI.Enums;
using CaspianChemichalsWebAPI.Utilites.Exceptions.Common;
using Microsoft.EntityFrameworkCore;

namespace CaspianChemichalsWebAPI.Implementations.Services
{
    public class OurPartnerTranslateService : IOurPartnerTranslateService
    {
        private readonly IOurPartnerTranslateRepo _repository;
        private readonly IMapper _mapper;
        private readonly IOurPartnerRepo _ourPartnerRepo;

        public OurPartnerTranslateService(IOurPartnerTranslateRepo repository,IMapper mapper,IOurPartnerRepo ourPartnerRepo)
        {
            _repository = repository;
            _mapper = mapper;
            _ourPartnerRepo = ourPartnerRepo;
        }
        public async Task<ICollection<OurPartnerTranslateItemDto>> GetAllAsync(int page, int take)
        {
            ICollection<OurPartnerTranslate> ourPartnerTranslates = await _repository.GetAllWhere(
                skip: (page - 1) * take, take: take).ToListAsync();
            return _mapper.Map<ICollection<OurPartnerTranslateItemDto>>(ourPartnerTranslates);
        }

        public async Task<OurPartnerTranslateItemDto> GetAsync(int id)
        {
            OurPartnerTranslate ourPartnerTranslate = await _repository.GetByIdAsync(id);
            return _mapper.Map<OurPartnerTranslateItemDto>(ourPartnerTranslate);
        }

        public async Task CreateAsync(OurPartnerTranslateCreateDto ourPartnerTranslateDto)
        {
            if (!await _ourPartnerRepo.IsExistAsync(x => x.Id == ourPartnerTranslateDto.OurPartnerId))
                throw new NotFoundException();
            bool isvalid = Enum.IsDefined(typeof(Language), ourPartnerTranslateDto.Language);
            if (!isvalid) throw new BadRequestException();
            bool translateExists = await _repository.IsExistAsync(x => 
            x.OurPartnerId== ourPartnerTranslateDto.OurPartnerId 
            && x.Language == ourPartnerTranslateDto.Language);
            if (translateExists)
                throw new BadRequestException("A translation for this language already exists.");
            OurPartnerTranslate ourPartnerTranslateTranslate = _mapper.Map<OurPartnerTranslate>(ourPartnerTranslateDto);
            await _repository.AddAsync(ourPartnerTranslateTranslate);
            await _repository.SaveChangesAsync();
        }

        public async Task UpdateAsync(OurPartnerTranslateUpdateDto ourPartnerTranslateDto, int id)
        {
            OurPartnerTranslate existed = await _repository.GetByIdAsync(id);
            if (existed == null) throw new NotFoundException();
            if (!await _ourPartnerRepo.IsExistAsync(x => x.Id == ourPartnerTranslateDto.OurPartnerId))
                throw new NotFoundException();
            bool isvalid = Enum.IsDefined(typeof(Language), ourPartnerTranslateDto.Language);
            if (!isvalid) throw new BadRequestException();
            existed = _mapper.Map(ourPartnerTranslateDto, existed);
            await _repository.UpdateAsync(existed);
        }
        public async Task DeleteAsync(int id)
        {
            OurPartnerTranslate existed = await _repository.GetByIdAsync(id);
            if (existed == null) throw new NotFoundException();
            await _repository.DeleteAsync(existed);
        }
    }
}
