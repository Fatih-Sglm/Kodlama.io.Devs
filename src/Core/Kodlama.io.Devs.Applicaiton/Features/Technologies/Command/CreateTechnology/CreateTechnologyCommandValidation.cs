using FluentValidation;

namespace Kodlama.io.Devs.Applicaiton.Features.Technologies.Command.CreateTechnology
{
    public class CreateTechnologyCommandValidation : AbstractValidator<CreateTechnologyCommand>
    {
        public CreateTechnologyCommandValidation()
        {
            RuleFor(x => x.Name).NotNull().WithMessage("Teknoloji Adı Boş Geçilemez");
        }
    }
}
