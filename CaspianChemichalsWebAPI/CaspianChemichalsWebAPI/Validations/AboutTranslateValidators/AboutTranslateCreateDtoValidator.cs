using CaspianChemichalsWebAPI.Dtos.AboutTranslatedDtos;
using FluentValidation;

namespace CaspianChemichalsWebAPI.Validations.AboutTranslateValidators
{
    public class AboutTranslateCreateDtoValidator:AbstractValidator<AboutTranslateCreateDto>
    {
        public AboutTranslateCreateDtoValidator()
        {
            RuleFor(x => x.Tittle)
                .NotEmpty().WithMessage("You must write tittle")
                .MaximumLength(200).WithMessage("You can send maximum 200 caracter in tittle");
            RuleFor(x => x.Description)
                .NotEmpty().WithMessage("You must write description")
                .MaximumLength(2500).WithMessage("You can send maximum 2500 caracter in tittle");
        }
    }
}
