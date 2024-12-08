using AutoMapper;
using CaspianChemichalsWebAPI.Abstraction.Repostories;
using CaspianChemichalsWebAPI.Abstraction.Services;
using CaspianChemichalsWebAPI.Dtos.SliderTranslateDtos;
using CaspianChemichalsWebAPI.Entities;
using CaspianChemichalsWebAPI.Enums;
using CaspianChemichalsWebAPI.Utilites.Exceptions.Common;
using Microsoft.EntityFrameworkCore;

namespace CaspianChemichalsWebAPI.Implementations.Services
{
    public class SliderTranslateService : ISliderTranslateService
    {
        private readonly ISliderTranslateRepo _repository;
        private readonly IMapper _mapper;
        private readonly ISliderRepo _sliderrepo;

        public SliderTranslateService(ISliderTranslateRepo repository,IMapper mapper,ISliderRepo sliderrepo)
        {
            _repository = repository;
            _mapper = mapper;
            _sliderrepo = sliderrepo;
        }
        public async Task<ICollection<SliderTranslateItemDto>> GetAllAsync(int page, int take)
        {
            ICollection<SliderTranslate> sliders = await _repository.GetAllWhere(
                skip: (page - 1) * take, take: take).ToListAsync();
            return _mapper.Map<ICollection<SliderTranslateItemDto>>(sliders);
        }

        public async Task<SliderTranslateItemDto> GetAsync(int id)
        {
            SliderTranslate slider = await _repository.GetByIdAsync(id);
            return _mapper.Map<SliderTranslateItemDto>(slider);
        }

        public async Task CreateAsync(SliderTranslateCreateDto sliderDto)
        {
            if (!await _sliderrepo.IsExistAsync(x => x.Id == sliderDto.SliderId))
                throw new NotFoundException();
            bool isvalid = Enum.IsDefined(typeof(Language), sliderDto.Language);
            if (!isvalid) throw new BadRequestException();
            bool translateExists = await _repository.IsExistAsync(x => x.SliderId == sliderDto.SliderId && x.Language == sliderDto.Language);
            if (translateExists)
                throw new BadRequestException("A translation for this language already exists.");
            SliderTranslate sliderTranslate = _mapper.Map<SliderTranslate>(sliderDto);
            await _repository.AddAsync(sliderTranslate);
            await _repository.SaveChangesAsync();
        }

        public async Task UpdateAsync(SliderTranslateUpdateDto sliderDto, int id)
        {
            SliderTranslate existed = await _repository.GetByIdAsync(id);
            if (existed == null) throw new NotFoundException();
            if (!await _sliderrepo.IsExistAsync(x => x.Id == sliderDto.SliderId))
                throw new NotFoundException();
            bool isvalid = Enum.IsDefined(typeof(Language), sliderDto.Language);
            if (!isvalid) throw new BadRequestException();
            existed = _mapper.Map(sliderDto, existed);
            await _repository.UpdateAsync(existed);
        }
        public async Task DeleteAsync(int id)
        {
            SliderTranslate existed = await _repository.GetByIdAsync(id);
            if (existed == null) throw new NotFoundException();
            await _repository.DeleteAsync(existed);
        }
    }
}
