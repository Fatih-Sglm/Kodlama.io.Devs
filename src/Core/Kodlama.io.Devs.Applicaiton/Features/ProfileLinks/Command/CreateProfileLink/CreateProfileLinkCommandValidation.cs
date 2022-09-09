using FluentValidation;

namespace Kodlama.io.Devs.Applicaiton.Features.ProfileLinks.Command.CreateProfileLink
{
    public class CreateProfileLinkCommandValidation : AbstractValidator<CreateProfileLinkCommand>
    {
        public CreateProfileLinkCommandValidation()
        {
            RuleFor(x => x.ProfileType).NotNull().WithMessage("Profile Url Cannot Be Empty");
            RuleFor(x => x.ProfileUrl).NotNull().WithMessage("Profile Url Cannot Be Empty");
        }
    }
}
