using CaspianChemichalsWebAPI.Dtos.SliderDtos;
using FluentValidation;

namespace CaspianChemichalsWebAPI.Validations.SliderValidators
{
    public class SliderCreateDtoValidator:AbstractValidator<SliderCreateDto>
    {
        public SliderCreateDtoValidator()
        {
            RuleFor(x => x.Tittle)
                .MaximumLength(200).WithMessage("You can send maximum 200 caracter")
                .NotEmpty().WithMessage("You can't send empty tittle");
            RuleFor(x => x.Subtittle)
                .MaximumLength(400).WithMessage("You can send maximum 200 caracter")
                .NotEmpty().WithMessage("You can't send empty subtittle");
            RuleFor(x => x.Image)
                .NotEmpty().WithMessage("You must send image");
        }
    }
}
