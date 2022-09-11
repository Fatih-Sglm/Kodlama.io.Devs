using FluentValidation;

namespace Kodlama.io.Devs.Applicaiton.Features.ProfileLinks.Command.UpdateProfileLink
{
    public class UpdateProfileLinkCommandValidation : AbstractValidator<UpdateProfileLinkCommand>
    {
        public UpdateProfileLinkCommandValidation()
        {
            RuleFor(x => x.ProfileUrl).NotNull().WithMessage("Profile Url Cannot Be Empty");
        }
    }
}
