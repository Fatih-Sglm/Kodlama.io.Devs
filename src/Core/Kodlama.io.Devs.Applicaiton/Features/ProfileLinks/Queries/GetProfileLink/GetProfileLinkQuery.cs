using AutoMapper;
using Kodlama.io.Devs.Applicaiton.Abstractions.Repositories;
using Kodlama.io.Devs.Applicaiton.Features.ProfileLinks.Dtos;
using Kodlama.io.Devs.Applicaiton.Features.ProfileLinks.Rules;
using Kodlama.io.Devs.Domain.Entities;
using MediatR;

namespace Kodlama.io.Devs.Applicaiton.Features.ProfileLinks.Queries.GetProfileLink
{
    public class GetProfileLinkQuery : IRequest<GetProfileLinkDto>
    {
        public Guid Id { get; set; }
        public class GetProfileLinkQueryHandler : IRequestHandler<GetProfileLinkQuery, GetProfileLinkDto>
        {
            private readonly IProfileLinksRepository _profileLinksRepository;
            private readonly ProfileLinksBusinessRules _profileLinksBusinessRules;
            private readonly IMapper _mapper;

            public GetProfileLinkQueryHandler(IProfileLinksRepository profileLinksRepository,
                ProfileLinksBusinessRules profileLinksBusinessRules, IMapper mapper)
            {
                _profileLinksRepository = profileLinksRepository;
                _profileLinksBusinessRules = profileLinksBusinessRules;
                _mapper = mapper;
            }

            public async Task<GetProfileLinkDto> Handle(GetProfileLinkQuery request, CancellationToken cancellationToken)
            {
                ProfileLink? profileLink = await _profileLinksRepository.GetAsync(x => x.Id == request.Id);
                await _profileLinksBusinessRules.CannotBeNull(profileLink);
                return _mapper.Map<GetProfileLinkDto>(profileLink);
            }
        }
    }
}
