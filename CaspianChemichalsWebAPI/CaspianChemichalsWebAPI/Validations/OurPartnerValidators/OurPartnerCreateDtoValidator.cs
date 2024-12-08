using CaspianChemichalsWebAPI.Dtos.OurPartnerDtos;
using FluentValidation;

namespace CaspianChemichalsWebAPI.Validations.OurPartnerValidators
{
    public class OurPartnerCreateDtoValidator:AbstractValidator<OurPartnerCreateDto>
    {
        public OurPartnerCreateDtoValidator()
        {
            RuleFor(x => x.Name)
                .MaximumLength(300).WithMessage("You can send maximum 300 caracter")
                .NotEmpty().WithMessage("You must send name");
            RuleFor(x => x.Logo)
                .NotEmpty().WithMessage("You must send logo");
        }
    }
}
