using Kodlama.io.Devs.Applicaiton.Abstractions.Services;
using Kodlama.io.Devs.Applicaiton.Features.ProfileLinks.Dtos;
using MediatR;

namespace Kodlama.io.Devs.Applicaiton.Features.ProfileLinks.Queries.GetProfileLink
{
    public class GetProfileLinkQuery : IRequest<GetProfileLinkDto>
    {
        public Guid Id { get; set; }
        public class GetProfileLinkQueryHandler : IRequestHandler<GetProfileLinkQuery, GetProfileLinkDto>
        {
            private readonly IProfileLinkService _profileLinkService;

            public async Task<GetProfileLinkDto> Handle(GetProfileLinkQuery request, CancellationToken cancellationToken)
            {
                return await _profileLinkService.GetById(request);
            }
        }
    }
}
