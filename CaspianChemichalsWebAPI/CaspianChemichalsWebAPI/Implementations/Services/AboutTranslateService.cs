using AutoMapper;
using CaspianChemichalsWebAPI.Abstraction.Repostories;
using CaspianChemichalsWebAPI.Abstraction.Services;
using CaspianChemichalsWebAPI.Dtos.AboutDtos;
using CaspianChemichalsWebAPI.Dtos.AboutTranslatedDtos;
using CaspianChemichalsWebAPI.Entities;
using CaspianChemichalsWebAPI.Enums;
using CaspianChemichalsWebAPI.Utilites.Exceptions.Common;
using Microsoft.EntityFrameworkCore;

namespace CaspianChemichalsWebAPI.Implementations.Services
{
    public class AboutTranslateService : IAboutTranslateService
    {
        private readonly IAboutTranslateRepo _repository;
        private readonly IMapper _mapper;
        private readonly IAboutRepo _aboutrepo;

        public AboutTranslateService(IAboutTranslateRepo repository,IMapper mapper,IAboutRepo aboutrepo)
        {
            _repository = repository;
            _mapper = mapper;
            _aboutrepo = aboutrepo;
        }
        public async Task<ICollection<AboutTranslateItemDto>> GetAllAsync(int page, int take)
        {
            ICollection<AboutTranslate> abouts = await _repository.GetAllWhere(
                skip: (page - 1) * take, take: take).ToListAsync();
            return _mapper.Map<ICollection<AboutTranslateItemDto>>(abouts);
        }

        public async Task<AboutTranslateItemDto> GetAsync(int id)
        {
            AboutTranslate about = await _repository.GetByIdAsync(id);
            return _mapper.Map<AboutTranslateItemDto>(about);
        }

        public async Task CreateAsync(AboutTranslateCreateDto aboutDto)
        {
            if (!await _aboutrepo.IsExistAsync(x => x.Id == aboutDto.AboutId))
                throw new NotFoundException();
            bool isvalid = Enum.IsDefined(typeof(Language), aboutDto.Language);
            if (!isvalid) throw new BadRequestException();
            bool translateExists = await _repository.IsExistAsync(x => x.AboutId == aboutDto.AboutId && x.Language == aboutDto.Language);
            if (translateExists)
                throw new BadRequestException("A translation for this language already exists.");
            AboutTranslate aboutTranslate=_mapper.Map<AboutTranslate>(aboutDto);
            await _repository.AddAsync(aboutTranslate);
            await _repository.SaveChangesAsync();
        }

        public async Task UpdateAsync(AboutTranslateUpdateDto aboutDto, int id)
        {
            AboutTranslate existed = await _repository.GetByIdAsync(id);
            if (existed == null) throw new NotFoundException();
            if (!await _aboutrepo.IsExistAsync(x => x.Id == aboutDto.AboutId))
                throw new NotFoundException();
            bool isvalid = Enum.IsDefined(typeof(Language), aboutDto.Language);
            if (!isvalid) throw new BadRequestException();
            existed = _mapper.Map(aboutDto, existed);
            await _repository.UpdateAsync(existed);
        }
        public async Task DeleteAsync(int id)
        {
            AboutTranslate existed=await _repository.GetByIdAsync(id);
            if (existed == null) throw new NotFoundException();
            await _repository.DeleteAsync(existed);
        }

        

    }
}
