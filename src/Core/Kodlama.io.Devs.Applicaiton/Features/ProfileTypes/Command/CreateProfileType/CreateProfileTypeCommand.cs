using MediatR;

namespace Kodlama.io.Devs.Applicaiton.Features.ProfileTypes.Command.CreateProfileType
{
    public class CreateProfileTypeCommand : IRequest<bool>
    {
        public string PType { get; set; }
    }
}
