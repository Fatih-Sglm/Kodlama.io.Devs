using FluentValidation;

namespace Kodlama.io.Devs.Applicaiton.Features.ProgramingLanguages.Command.CreateCommand
{
    public class CreateProgramingLanguageValidation : AbstractValidator<CreateProgramingLanguageCommand>
    {
        public CreateProgramingLanguageValidation()
        {
            RuleFor(c => c.Name).NotNull().WithMessage("Programing Language Name Cannot be NULL!");
            RuleFor(c => c.Name).MinimumLength(2).WithMessage("Programlama dili en az 2 haneli olmak zorundadır");
        }
    }
}
