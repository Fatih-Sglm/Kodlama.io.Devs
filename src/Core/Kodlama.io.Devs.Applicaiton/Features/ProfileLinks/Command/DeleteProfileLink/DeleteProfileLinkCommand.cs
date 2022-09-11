using Kodlama.io.Devs.Applicaiton.Features.ProfileLinks.Rules;
using Kodlama.io.Devs.Applicaiton.Services.Repositories;
using Kodlama.io.Devs.Domain.Entities;
using MediatR;

namespace Kodlama.io.Devs.Applicaiton.Features.ProfileLinks.Command.DeleteProfileLink
{
    public class DeleteProfileLinkCommand : IRequest<bool>
    {
        public Guid Id { get; set; }

        public class DeleteProfileLinkCommandHandler : IRequestHandler<DeleteProfileLinkCommand, bool>
        {
            private readonly IProfileLinksRepository _profileLinksRepository;
            private readonly ProFileLinksBusinessRules _proFileLinksRules;
            public DeleteProfileLinkCommandHandler(IProfileLinksRepository profileLinksRepository, ProFileLinksBusinessRules proFileLinksRules)
            {
                _profileLinksRepository = profileLinksRepository;
                _proFileLinksRules = proFileLinksRules;
            }

            public async Task<bool> Handle(DeleteProfileLinkCommand request, CancellationToken cancellationToken)
            {
                ProfileLink? value = await _profileLinksRepository.GetAsync(x => x.Id == request.Id);
                await _proFileLinksRules.CannotBeNull(value);
                await _profileLinksRepository.DeleteAsync(value);
                return true;
            }
        }
    }
}
