using AutoMapper;
using Kodlama.io.Devs.Applicaiton.Features.ProfileLinks.Dtos;
using Kodlama.io.Devs.Applicaiton.Features.ProfileLinks.Rules;
using Kodlama.io.Devs.Applicaiton.Services.Repositories;
using Kodlama.io.Devs.Domain.Entities;
using MediatR;

namespace Kodlama.io.Devs.Applicaiton.Features.ProfileLinks.Queries.GetProfileLink
{
    public class GetProfileLinkQuery : IRequest<GetProfileLinkDto>
    {
        public Guid Id { get; set; }

        public class GetProfileLinkQueryHandler : IRequestHandler<GetProfileLinkQuery, GetProfileLinkDto>
        {
            private readonly IMapper _mapper;
            private readonly IProfileLinksRepository _profileLinksRepository;
            private readonly ProFileLinksBusinessRules _proFileLinksRules;

            public GetProfileLinkQueryHandler(IMapper mapper, IProfileLinksRepository profileLinksRepository, ProFileLinksBusinessRules proFileLinksRules)
            {
                _mapper = mapper;
                _profileLinksRepository = profileLinksRepository;
                _proFileLinksRules = proFileLinksRules;
            }

            public async Task<GetProfileLinkDto> Handle(GetProfileLinkQuery request, CancellationToken cancellationToken)
            {
                ProfileLink profileLink = await _profileLinksRepository.GetAsync(x => x.Id == request.Id);
                _proFileLinksRules.PrfileLİnkMustExist(profileLink);
                return _mapper.Map<GetProfileLinkDto>(profileLink);
            }
        }
    }
}
