using AutoMapper;
using CaspianChemichalsWebAPI.Abstraction.Repostories;
using CaspianChemichalsWebAPI.Abstraction.Services;
using CaspianChemichalsWebAPI.Dtos.OurPartnerDtos;
using CaspianChemichalsWebAPI.Entities;
using CaspianChemichalsWebAPI.Enums;
using CaspianChemichalsWebAPI.Utilites.Exceptions.Common;
using CaspianChemichalsWebAPI.Utilites.Helpers;
using Microsoft.EntityFrameworkCore;

namespace CaspianChemichalsWebAPI.Implementations.Services
{
    public class OurPartnerService : IOurPartnerService
    {
        private readonly IOurPartnerRepo _repository;
        private readonly IMapper _mapper;
        private readonly ICloudinaryService _cloudinaryService;
        private readonly IOurPartnerTranslateRepo _ourPartnerTranslateRepo;

        public OurPartnerService(IOurPartnerRepo repository,IMapper mapper,ICloudinaryService cloudinaryService,IOurPartnerTranslateRepo ourPartnerTranslateRepo)
        {
            _repository = repository;
            _mapper = mapper;
            _cloudinaryService = cloudinaryService;
            _ourPartnerTranslateRepo = ourPartnerTranslateRepo;
        }
        public async Task<ICollection<OurPartnerItemDto>> GetAllAsync(int page, int take)
        {
            ICollection<OurPartner> ourpartners = await _repository.GetAllWhere(
                skip: (page - 1) * take, take: take).ToListAsync();
            return _mapper.Map<ICollection<OurPartnerItemDto>>(ourpartners);
        }
        public async Task<ICollection<OurPartnerItemDto>> GetAllTranslatedAsync(int page,
            Language language, int take)
        {
            ICollection<OurPartner> ourpartners = await _repository.GetAllWhere(
            skip: (page - 1) * take, take: take).ToListAsync();

            ICollection<OurPartnerItemDto> ourpartnerItemDtos = _mapper.Map<ICollection<OurPartnerItemDto>>(ourpartners);

            ICollection<OurPartnerTranslate> translates = await _ourPartnerTranslateRepo
                .GetAllWhereTranslated(language: language, skip: (page - 1) * take, take: take)
                .ToListAsync();

            foreach (var translate in translates)
            {
                var ourpartnerItemDto = ourpartnerItemDtos.FirstOrDefault(dto => dto.Id == translate.OurPartnerId);
                if (ourpartnerItemDto != null)
                {
                    ourpartnerItemDto.Name = translate.Name ?? ourpartnerItemDto.Name;
                }
            }
            return ourpartnerItemDtos;
        }
        public async Task<OurPartnerItemDto> GetAsync(int id)
        {
            OurPartner ourpartner = await _repository.GetByIdAsync(id);
            return _mapper.Map<OurPartnerItemDto>(ourpartner);
        }
        public async Task<OurPartnerItemDto> GetTranslatedAsync(int id, Language language)
        {
            OurPartner ourpartner = await _repository.GetByIdAsync(id);
            OurPartnerItemDto ourpartnerDto = _mapper.Map<OurPartnerItemDto>(ourpartner);
            OurPartnerTranslate translate = await _ourPartnerTranslateRepo.GetByExpressionTranslatedAsync(
                x => x.OurPartnerId == id,
                language: language);
            if (translate != null)
            {
                ourpartnerDto.Name = translate.Name ?? ourpartnerDto.Name;
            }
            return ourpartnerDto;
        }

        public async Task CreateAsync(OurPartnerCreateDto ourpartnerdto)
        {
            ourpartnerdto.Logo.ValidateImage();
            OurPartner ourpartner = _mapper.Map<OurPartner>(ourpartnerdto);
            ourpartner.Logo = await _cloudinaryService.FileCreateAsync(ourpartnerdto.Logo);
            await _repository.AddAsync(ourpartner);
            await _repository.SaveChangesAsync();
        }

        public async Task UpdateAsync(OurPartnerUpdateDto ourpartnerdto, int id)
        {
            OurPartner existed = await _repository.GetByIdAsync(id);
            if (existed == null) throw new NotFoundException();
            existed = _mapper.Map(ourpartnerdto, existed);

            if (ourpartnerdto.NewLogo != null)
            {
                ourpartnerdto.NewLogo.ValidateImage();
                var result = await _cloudinaryService.FileDeleteAsync(existed.Logo);
                if (result == false) throw new UnDeleteException();
                existed.Logo = await _cloudinaryService.FileCreateAsync(ourpartnerdto.NewLogo);
            }
            await _repository.UpdateAsync(existed);
        }
        public async Task DeleteAsync(int id)
        {
            OurPartner existed = await _repository.GetByIdAsync(id);
            if (existed == null) throw new NotFoundException();
            var result = await _cloudinaryService.FileDeleteAsync(existed.Logo);
            if (result == false) throw new UnDeleteException();
            await _repository.DeleteAsync(existed);
        }
    }
}
