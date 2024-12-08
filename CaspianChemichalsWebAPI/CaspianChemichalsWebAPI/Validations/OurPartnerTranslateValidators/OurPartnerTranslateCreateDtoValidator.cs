using CaspianChemichalsWebAPI.Dtos.OurPartnerTranslateDtos;
using FluentValidation;

namespace CaspianChemichalsWebAPI.Validations.OurPartnerTranslateValidators
{
    public class OurPartnerTranslateCreateDtoValidator:AbstractValidator<OurPartnerTranslateCreateDto>
    {
        public OurPartnerTranslateCreateDtoValidator()
        {
            RuleFor(x=>x.Name)
                .MaximumLength(300).WithMessage("You can send maximum 300 caracter")
                .NotEmpty().WithMessage("You must send name");
        }
    }
}
