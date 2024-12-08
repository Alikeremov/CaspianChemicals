using CaspianChemichalsWebAPI.Dtos.SliderTranslateDtos;
using FluentValidation;

namespace CaspianChemichalsWebAPI.Validations.SliderTranslateValidators
{
    public class SliderTranslateUpdateDtoValidator:AbstractValidator<SliderTranslateUpdateDto>
    {
        public SliderTranslateUpdateDtoValidator()
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
