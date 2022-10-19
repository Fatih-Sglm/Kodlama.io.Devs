using AutoMapper;
using Core.Application.Pipelines.Authorization;
using Kodlama.io.Devs.Applicaiton.Abstractions.Repositories;
using Kodlama.io.Devs.Applicaiton.Features.ProfileLinks.Command.CreateProfileLink;
using Kodlama.io.Devs.Applicaiton.Features.ProfileLinks.Rules;
using Kodlama.io.Devs.Domain.Entities;
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
            private readonly IProfileLinksRepository _profileLinksRepository;
            private readonly ProfileLinksBusinessRules _profileLinksBusinessRules;
            private readonly IMapper _mapper;

            public UpdateProfileLinkCommandHandler(IProfileLinksRepository profileLinksRepository,
                ProfileLinksBusinessRules profileLinksBusinessRules, IMapper mapper)
            {
                _profileLinksRepository = profileLinksRepository;
                _profileLinksBusinessRules = profileLinksBusinessRules;
                _mapper = mapper;
            }

            public async Task<bool> Handle(UpdateProfileLinkCommand request, CancellationToken cancellationToken)
            {
                ProfileLink? profile = await _profileLinksRepository.GetAsync(x => x.Id == request.Id);
                await _profileLinksBusinessRules.CannotBeNull(profile);
                await _profileLinksRepository.UpdateAsync(_mapper.Map(request, profile));
                return true;
            }
        }
    }
}
