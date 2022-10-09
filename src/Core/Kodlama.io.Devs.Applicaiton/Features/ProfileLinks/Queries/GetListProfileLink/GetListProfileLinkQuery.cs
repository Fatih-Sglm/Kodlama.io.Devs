using Core.Application.Pipelines.Authorization;
using Core.Application.Requests;
using Kodlama.io.Devs.Applicaiton.Abstractions.Services;
using Kodlama.io.Devs.Applicaiton.Features.ProfileLinks.Models;
using MediatR;

namespace Kodlama.io.Devs.Applicaiton.Features.ProfileLinks.Queries.GetListProfileLink
{
    public class GetListProfileLinkQuery : IRequest<GetListProfileLinkModel>, ISecuredRequest
    {
        public PageRequest PageRequest { get; set; }

        public string[] Roles => new string[] { "admin", "user" };

        public class GetListProfileLinkQueryHandler : IRequestHandler<GetListProfileLinkQuery, GetListProfileLinkModel>
        {
            private readonly IProfileLinkService _profileLinkService;

            public GetListProfileLinkQueryHandler(IProfileLinkService profileLinkService)
            {
                _profileLinkService = profileLinkService;
            }

            public async Task<GetListProfileLinkModel> Handle(GetListProfileLinkQuery request, CancellationToken cancellationToken)
            {
                return await _profileLinkService.Get(request);
            }
        }
    }
}
