using AutoMapper;
using Core.Application.Pipelines.Authorization;
using Kodlama.io.Devs.Applicaiton.Abstractions.Repositories;
using Kodlama.io.Devs.Applicaiton.Features.ProfileLinks.Rules;
using Kodlama.io.Devs.Domain.Entities;
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
            private readonly IProfileLinksRepository _profileLinksRepository;
            private readonly ProfileLinksBusinessRules _profileLinksBusinessRules;
            private readonly IMapper _mapper;

            public CreateProfileLinkCommandHandler(IProfileLinksRepository profileLinksRepository,
                ProfileLinksBusinessRules profileLinksBusinessRules,
                IMapper mapper)
            {
                _profileLinksRepository = profileLinksRepository;
                _profileLinksBusinessRules = profileLinksBusinessRules;
                _mapper = mapper;
            }

            public async Task<bool> Handle(CreateProfileLinkCommand request, CancellationToken cancellationToken)
            {
                await _profileLinksBusinessRules.CanNotDuplicate(request.ProfileUrl);
                await _profileLinksRepository.AddAsync(_mapper.Map<ProfileLink>(request));
                return true;
            }
        }
    }
}
