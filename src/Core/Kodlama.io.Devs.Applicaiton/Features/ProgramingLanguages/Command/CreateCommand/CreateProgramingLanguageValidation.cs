﻿using FluentValidation;

namespace Kodlama.io.Devs.Applicaiton.Features.ProgramingLanguages.Command.CreateCommand
{
    public class CreateProgramingLanguageValidation : AbstractValidator<CreateProgramingLanguageCommand>
    {
        public CreateProgramingLanguageValidation()
        {
            RuleFor(c => c.Name).NotNull().WithMessage("Programing Language Name Cannot be NULL!");
        }
    }
}
