using Core.Application.Pipelines.Authorization;
using Kodlama.io.Devs.Applicaiton.Abstractions.Services;
using Kodlama.io.Devs.Applicaiton.Features.ProfileLinks.Command.CreateProfileLink;
using MediatR;

namespace Kodlama.io.Devs.Applicaiton.Features.ProfileLinks.Command.UpdateProfileLink
{
    public class UpdateProfileLinkCommand : IRequest<bool>, ISecuredRequest
    {
        public Guid Id { get; set; }
        public Guid ProfileTypeId { get; set; }
        public string ProfileUrl { get; set; }

        public string[] Roles => new[] { nameof(CreateProfileLinkCommand) };


        public class UpdateProfileLinkCommandHandler : IRequestHandler<UpdateProfileLinkCommand, bool>
        {
            private readonly IProfileLinkService _profileLinkService;

            public UpdateProfileLinkCommandHandler(IProfileLinkService profileLinkService)
            {
                _profileLinkService = profileLinkService;
            }

            public async Task<bool> Handle(UpdateProfileLinkCommand request, CancellationToken cancellationToken)
            {
                await _profileLinkService.Update(request);
                return true;
            }
        }
    }
}
