using Core.Application.Pipelines.Authorization;
using Kodlama.io.Devs.Applicaiton.Abstractions.Services;
using MediatR;

namespace Kodlama.io.Devs.Applicaiton.Features.ProfileLinks.Command.DeleteProfileLink
{
    public class DeleteProfileLinkCommand : IRequest<bool>, ISecuredRequest
    {
        public Guid Id { get; set; }

        public string[] Roles => new[] { nameof(DeleteProfileLinkCommand) };

        public class DeleteProfileLinkCommandHandler : IRequestHandler<DeleteProfileLinkCommand, bool>
        {
            private readonly IProfileLinkService _profileLinkService;

            public DeleteProfileLinkCommandHandler(IProfileLinkService profileLinkService)
            {
                _profileLinkService = profileLinkService;
            }

            public async Task<bool> Handle(DeleteProfileLinkCommand request, CancellationToken cancellationToken)
            {
                await _profileLinkService.Delete(request);
                return true;
            }
        }
    }
}
