using FluentValidation;

namespace Kodlama.io.Devs.Applicaiton.Features.Technologies.Command.UpdateTechnology
{
    public class UpdateTechnologyCommandValidator : AbstractValidator<UpdateTechnologyCommand>
    {
        public UpdateTechnologyCommandValidator()
        {
            RuleFor(x => x.Name).NotNull().WithMessage("Teknoloji Adı Boş Geçilemez");
        }
    }
}
