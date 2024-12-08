using CaspianChemichalsWebAPI.Abstraction.Services;
using CaspianChemichalsWebAPI.Dtos.AboutDtos;
using CaspianChemichalsWebAPI.Dtos.OurPartnerDtos;
using CaspianChemichalsWebAPI.Enums;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CaspianChemichalsWebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class OurPartnersController : ControllerBase
    {
        private readonly IOurPartnerService _service;

        public OurPartnersController(IOurPartnerService service)
        {
            _service = service;
        }
        [HttpGet]
        public async Task<IActionResult> Get(int page = 1, int take = 3)
        {
            return StatusCode(StatusCodes.Status200OK, await _service.GetAllAsync(page, take));
        }
        [HttpGet]
        public async Task<IActionResult> GetTranslates(Language language, int page = 1, int take = 3)
        {
            return StatusCode(StatusCodes.Status200OK,
                await _service.GetAllTranslatedAsync(page, language: language, take));
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            if (id <= 0) return StatusCode(StatusCodes.Status400BadRequest);
            return StatusCode(StatusCodes.Status200OK, await _service.GetAsync(id));
        }
        [HttpGet("{id}/translated")]
        public async Task<IActionResult> Get(int id, Language language)
        {
            if (id <= 0) return StatusCode(StatusCodes.Status400BadRequest);
            return StatusCode(StatusCodes.Status200OK, await _service.GetTranslatedAsync(id, language));
        }
        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromForm] OurPartnerCreateDto ourPartnerDto)
        {
            await _service.CreateAsync(ourPartnerDto);
            return StatusCode(StatusCodes.Status200OK);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync([FromForm] OurPartnerUpdateDto updateDto, int id)
        {
            if (id <= 0) return StatusCode(StatusCodes.Status400BadRequest);
            await _service.UpdateAsync(updateDto, id);
            return StatusCode(StatusCodes.Status200OK);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            if (id <= 0) return StatusCode(StatusCodes.Status400BadRequest);
            await _service.DeleteAsync(id);
            return StatusCode(StatusCodes.Status200OK);
        }
    }
}
