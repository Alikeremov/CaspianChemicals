using CaspianChemichalsWebAPI.Dtos.SliderDtos;
using FluentValidation;

namespace CaspianChemichalsWebAPI.Validations.SliderValidators
{
    public class SliderUpdateDtoValidator:AbstractValidator<SliderUpdateDto>
    {
        public SliderUpdateDtoValidator()
        {
            RuleFor(x => x.Tittle)
                .MaximumLength(200).WithMessage("You can send maximum 200 caracter")
                .NotEmpty().WithMessage("You can't send empty tittle");
            RuleFor(x => x.Subtittle)
                .MaximumLength(400).WithMessage("You can send maximum 200 caracter")
                .NotEmpty().WithMessage("You can't send empty subtittle");
            
        }
    }
}
