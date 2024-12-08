using CaspianChemichalsWebAPI.Dtos.OurPartnerDtos;
using FluentValidation;

namespace CaspianChemichalsWebAPI.Validations.OurPartnerValidators
{
    public class OurPartnerUpdateDtoValidator:AbstractValidator<OurPartnerUpdateDto>
    {
        public OurPartnerUpdateDtoValidator()
        {
            RuleFor(x => x.Name)
                .MaximumLength(300).WithMessage("You can send maximum 300 caracter")
                .NotEmpty().WithMessage("You must send name");
        }
    }
}
