using Kodlama.io.Devs.Applicaiton.Abstractions.Services;
using MediatR;

namespace Kodlama.io.Devs.Applicaiton.Features.ProfileTypes.Command.CreateProfileType
{
    public class CreateProfileTypeCommand : IRequest<bool>
    {
        public string PType { get; set; }

        public class CreateProfileTypeCommandHandler : IRequestHandler<CreateProfileTypeCommand, bool>
        {
            private readonly IProfileTypeService _profileTypeService;
            public CreateProfileTypeCommandHandler(IProfileTypeService profileTypeService)
            {
                _profileTypeService = profileTypeService;
            }

            public async Task<bool> Handle(CreateProfileTypeCommand request, CancellationToken cancellationToken)
            {
                await _profileTypeService.Create(request);
                return true;
            }
        }
    }
}

