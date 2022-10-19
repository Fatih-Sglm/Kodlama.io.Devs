using Core.Application.Pipelines.Authorization;
using Kodlama.io.Devs.Applicaiton.Abstractions.Repositories;
using Kodlama.io.Devs.Applicaiton.Features.ProfileLinks.Rules;
using Kodlama.io.Devs.Domain.Entities;
using MediatR;

namespace Kodlama.io.Devs.Applicaiton.Features.ProfileLinks.Command.DeleteProfileLink
{
    public class DeleteProfileLinkCommand : IRequest<bool>, ISecuredRequest
    {
        public Guid Id { get; set; }

        public string[] Roles => new[] { nameof(DeleteProfileLinkCommand) };

        public class DeleteProfileLinkCommandHandler : IRequestHandler<DeleteProfileLinkCommand, bool>
        {
            private readonly IProfileLinksRepository _profileLinksRepository;
            private readonly ProfileLinksBusinessRules _profileLinksBusinessRules;

            public DeleteProfileLinkCommandHandler(IProfileLinksRepository profileLinksRepository,
                ProfileLinksBusinessRules profileLinksBusinessRules)
            {
                _profileLinksRepository = profileLinksRepository;
                _profileLinksBusinessRules = profileLinksBusinessRules;
            }

            public async Task<bool> Handle(DeleteProfileLinkCommand request, CancellationToken cancellationToken)
            {
                ProfileLink? value = await _profileLinksRepository.GetAsync(x => x.Id == request.Id);
                await _profileLinksBusinessRules.CannotBeNull(value);
                await _profileLinksRepository.DeleteAsync(value);
                return true;
            }
        }
    }
}
