using AutoMapper;
using CaspianChemichalsWebAPI.Abstraction.Repostories;
using CaspianChemichalsWebAPI.Abstraction.Services;
using CaspianChemichalsWebAPI.Dtos.SliderDtos;
using CaspianChemichalsWebAPI.Entities;
using CaspianChemichalsWebAPI.Enums;
using CaspianChemichalsWebAPI.Utilites.Exceptions.Common;
using CaspianChemichalsWebAPI.Utilites.Helpers;
using Microsoft.EntityFrameworkCore;

namespace CaspianChemichalsWebAPI.Implementations.Services
{
    public class SliderService : ISliderService
    {
        private readonly ISliderRepo _repository;
        private readonly IMapper _mapper;
        private readonly ICloudinaryService _cloudinaryService;
        private readonly ISliderTranslateRepo _sliderTranslateRepo;

        public SliderService(ISliderRepo repository,IMapper mapper,ICloudinaryService cloudinaryService,ISliderTranslateRepo sliderTranslateRepo)
        {
            _repository = repository;
            _mapper = mapper;
            _cloudinaryService = cloudinaryService;
            _sliderTranslateRepo = sliderTranslateRepo;
        }
        public async Task<ICollection<SliderItemDto>> GetAllAsync(int page, int take)
        {
            ICollection<Slider> sliders = await _repository.GetAllWhere(
                skip: (page - 1) * take, take: take).ToListAsync();
            return _mapper.Map<ICollection<SliderItemDto>>(sliders);
        }
        public async Task<ICollection<SliderItemDto>> GetAllTranslatedAsync(int page,
            Language language, int take)
        {
            ICollection<Slider> sliders = await _repository.GetAllWhere(
            skip: (page - 1) * take, take: take).ToListAsync();

            ICollection<SliderItemDto> sliderItemDtos = _mapper.Map<ICollection<SliderItemDto>>(sliders);

            ICollection<SliderTranslate> translates = await _sliderTranslateRepo
                .GetAllWhereTranslated(language: language, skip: (page - 1) * take, take: take)
                .ToListAsync();

            foreach (var translate in translates)
            {
                var sliderItemDto = sliderItemDtos.FirstOrDefault(dto => dto.Id == translate.SliderId);
                if (sliderItemDto != null)
                {
                    sliderItemDto.Tittle = translate.Tittle ?? sliderItemDto.Tittle;
                    sliderItemDto.Subtittle = translate.Subtittle ?? sliderItemDto.Subtittle;
                }
            }
            return sliderItemDtos;
        }
        public async Task<SliderItemDto> GetAsync(int id)
        {
            Slider slider = await _repository.GetByIdAsync(id);
            return _mapper.Map<SliderItemDto>(slider);
        }
        public async Task<SliderItemDto> GetTranslatedAsync(int id, Language language)
        {
            Slider slider = await _repository.GetByIdAsync(id);
            SliderItemDto sliderDto = _mapper.Map<SliderItemDto>(slider);
            SliderTranslate translate = await _sliderTranslateRepo.GetByExpressionTranslatedAsync(
                x => x.SliderId == id,
                language: language);
            if (translate != null)
            {
                sliderDto.Tittle = translate.Tittle ?? sliderDto.Tittle;
                sliderDto.Subtittle = translate.Subtittle ?? sliderDto.Subtittle;
            }
            return sliderDto;
        }

        public async Task CreateAsync(SliderCreateDto sliderdto)
        {
            sliderdto.Image.ValidateImage();
            Slider slider = _mapper.Map<Slider>(sliderdto);
            slider.Image = await _cloudinaryService.FileCreateAsync(sliderdto.Image);
            await _repository.AddAsync(slider);
            await _repository.SaveChangesAsync();
        }

        public async Task UpdateAsync(SliderUpdateDto sliderdto, int id)
        {
            Slider existed = await _repository.GetByIdAsync(id);
            if (existed == null) throw new NotFoundException();
            existed = _mapper.Map(sliderdto, existed);

            if (sliderdto.NewImage != null)
            {
                sliderdto.NewImage.ValidateImage();
                var result = await _cloudinaryService.FileDeleteAsync(existed.Image);
                if (result == false) throw new UnDeleteException();
                existed.Image = await _cloudinaryService.FileCreateAsync(sliderdto.NewImage);
            }
            await _repository.UpdateAsync(existed);
        }
        public async Task DeleteAsync(int id)
        {
            Slider existed = await _repository.GetByIdAsync(id);
            if (existed == null) throw new NotFoundException();
            var result = await _cloudinaryService.FileDeleteAsync(existed.Image);
            if (result == false) throw new UnDeleteException();
            await _repository.DeleteAsync(existed);
        }
    }
}
