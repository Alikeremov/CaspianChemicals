using AutoMapper;
using CaspianChemichalsWebAPI.Abstraction.Repostories;
using CaspianChemichalsWebAPI.Abstraction.Services;
using CaspianChemichalsWebAPI.Dtos.AboutDtos;
using CaspianChemichalsWebAPI.Entities;
using CaspianChemichalsWebAPI.Enums;
using CaspianChemichalsWebAPI.Utilites.Exceptions.Common;
using CaspianChemichalsWebAPI.Utilites.Helpers;
using Microsoft.EntityFrameworkCore;

namespace CaspianChemichalsWebAPI.Implementations.Services
{
    public class AboutService : IAboutService
    {
        private readonly IAboutRepo _repository;
        private readonly IMapper _mapper;
        private readonly ICloudinaryService _cloudinaryService;
        private readonly IAboutTranslateRepo _aboutTranslateRepo;

        public AboutService(IAboutRepo repository, IMapper mapper, ICloudinaryService cloudinaryService,IAboutTranslateRepo aboutTranslateRepo)
        {
            _repository = repository;
            
            _mapper = mapper;
            _cloudinaryService = cloudinaryService;
            _aboutTranslateRepo = aboutTranslateRepo;
        }
        public async Task<ICollection<AboutItemDto>> GetAllAsync(int page, int take)
        {
            ICollection<About> abouts = await _repository.GetAllWhere(
                skip: (page - 1) * take, take: take).ToListAsync();
            return _mapper.Map<ICollection<AboutItemDto>>(abouts);
        }
        public async Task<ICollection<AboutItemDto>> GetAllTranslatedAsync(int page,
            Language language, int take)
        {
            ICollection<About> abouts = await _repository.GetAllWhere(
            skip: (page - 1) * take, take: take).ToListAsync();

            ICollection<AboutItemDto> aboutItemDtos = _mapper.Map<ICollection<AboutItemDto>>(abouts);

            ICollection<AboutTranslate> translates = await _aboutTranslateRepo
                .GetAllWhereTranslated(language: language, skip: (page - 1) * take, take: take)
                .ToListAsync();

            foreach (var translate in translates)
            {
                var aboutItemDto = aboutItemDtos.FirstOrDefault(dto => dto.Id == translate.AboutId);
                if (aboutItemDto != null)
                {
                    aboutItemDto.Tittle = translate.Tittle ?? aboutItemDto.Tittle;
                    aboutItemDto.Description = translate.Description ?? aboutItemDto.Description;
                }
            }
            return aboutItemDtos;
        }
        public async Task<AboutItemDto> GetAsync(int id)
        {
            About about = await _repository.GetByIdAsync(id);
            return _mapper.Map<AboutItemDto>(about);
        }
        public async Task<AboutItemDto> GetTranslatedAsync(int id,Language language)
        {
            About about = await _repository.GetByIdAsync(id);
            AboutItemDto aboutDto = _mapper.Map<AboutItemDto>(about);
            AboutTranslate translate = await _aboutTranslateRepo.GetByExpressionTranslatedAsync(
                x => x.AboutId == id,
                language: language);
            if (translate != null)
            {
                aboutDto.Tittle = translate.Tittle ?? aboutDto.Tittle;
                aboutDto.Description = translate.Description ?? aboutDto.Description;
            }
            else
            {
                // Tərcümə tapılmadıqda orijinal məlumatla qaytarın
                aboutDto.Tittle = "Default Title";  // Default fallback dəyərləri
                aboutDto.Description =  "Default Description";  // Default fallback dəyərləri
            }
            return aboutDto;
        }

        public async Task CreateAsync(AboutCreateDto aboutdto)
        {
            aboutdto.Image.ValidateImage();
            About about = _mapper.Map<About>(aboutdto);
            about.Image = await _cloudinaryService.FileCreateAsync(aboutdto.Image);
            await _repository.AddAsync(about);
            await _repository.SaveChangesAsync();
        }

        public async Task UpdateAsync(AboutUpdateDto aboutdto, int id)
        {
            About existed = await _repository.GetByIdAsync(id);
            if (existed == null) throw new NotFoundException();
            existed = _mapper.Map(aboutdto, existed);

            if (aboutdto.NewImage != null)
            {
                aboutdto.NewImage.ValidateImage();
                var result = await _cloudinaryService.FileDeleteAsync(existed.Image);
                if (result == false) throw new UnDeleteException();
                existed.Image = await _cloudinaryService.FileCreateAsync(aboutdto.NewImage);
            }
            await _repository.UpdateAsync(existed);
        }
        public async Task DeleteAsync(int id)
        {
            About existed = await _repository.GetByIdAsync(id);
            if (existed == null) throw new NotFoundException();
            var result = await _cloudinaryService.FileDeleteAsync(existed.Image);
            if (result == false) throw new UnDeleteException();
            await _repository.DeleteAsync(existed);
        }


    }

}
