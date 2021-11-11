using Entities.Dtos;
using FluentValidation;

namespace SQLServerBased.API.Validators.Compounds
{
    public class CompoundForCreationDtoValidator : AbstractValidator<CompoundForCreationDto>
    {
        public CompoundForCreationDtoValidator()
        {
            RuleFor(x => x.MolecularFormula).NotEmpty();
        }
    }
}
