using Core.Application.Pipelines.Authorization;
using Kodlama.io.Devs.Applicaiton.Abstractions.Services;
using MediatR;

namespace Kodlama.io.Devs.Applicaiton.Features.ProfileLinks.Command.CreateProfileLink
{
    public class CreateProfileLinkCommand : IRequest<bool>, ISecuredRequest
    {
        public Guid ProfileTypeId { get; set; }
        public string ProfileUrl { get; set; }
        public Guid? AppUserId { get; set; }

        public string[] Roles => new[] { nameof(CreateProfileLinkCommand) };
        public class CreateProfileLinkCommandHandler : IRequestHandler<CreateProfileLinkCommand, bool>
        {
            private readonly IProfileLinkService _profileLinkService;

            public CreateProfileLinkCommandHandler(IProfileLinkService profileLinkService)
            {
                _profileLinkService = profileLinkService;
            }

            public async Task<bool> Handle(CreateProfileLinkCommand request, CancellationToken cancellationToken)
            {
                await _profileLinkService.Create(request);
                return true;
            }
        }
    }
}
