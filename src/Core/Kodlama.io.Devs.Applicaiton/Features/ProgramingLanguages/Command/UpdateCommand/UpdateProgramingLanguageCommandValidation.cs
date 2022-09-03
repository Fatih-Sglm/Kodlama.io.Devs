using FluentValidation;

namespace Kodlama.io.Devs.Applicaiton.Features.ProgramingLanguages.Command.UpdateCommand
{
    public class UpdateProgramingLanguageCommandValidation : AbstractValidator<UpdateProgramingLanguageCommand>
    {
        public UpdateProgramingLanguageCommandValidation()
        {
            RuleFor(c => c.Name).NotNull().WithMessage("Programing Language  Cannot be NULL!");
        }
    }
}
