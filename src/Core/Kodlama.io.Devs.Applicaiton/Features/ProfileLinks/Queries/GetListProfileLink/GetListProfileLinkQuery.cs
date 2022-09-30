using AutoMapper;
using Core.Application.Pipelines.Authorization;
using Core.Application.Requests;
using Core.Persistence.Paging;
using Kodlama.io.Devs.Applicaiton.Features.ProfileLinks.Models;
using Kodlama.io.Devs.Applicaiton.Services.Repositories;
using Kodlama.io.Devs.Domain.Entities;
using MediatR;

namespace Kodlama.io.Devs.Applicaiton.Features.ProfileLinks.Queries.GetListProfileLink
{
    public class GetListProfileLinkQuery : IRequest<GetListProfileLinkModel>, ISecuredRequest
    {
        public PageRequest PageRequest { get; set; }

        public string[] Roles => new string[] { "admin", "user" };

        public class GetListProfileLinkQueryHandler : IRequestHandler<GetListProfileLinkQuery, GetListProfileLinkModel>
        {
            private readonly IMapper _mapper;
            private readonly IProfileLinksRepository _profileLinksRepository;

            public GetListProfileLinkQueryHandler(IMapper mapper, IProfileLinksRepository profileLinksRepository)
            {
                _mapper = mapper;
                _profileLinksRepository = profileLinksRepository;
            }

            public async Task<GetListProfileLinkModel> Handle(GetListProfileLinkQuery request, CancellationToken cancellationToken)
            {
                //var val = _httpContextAccessor.HttpContext.User.ClaimRoles()
                IPaginate<ProfileLink> obj = await _profileLinksRepository.GetListAsync(index: request.PageRequest.Page, size: request.PageRequest.PageSize);
                return _mapper.Map<GetListProfileLinkModel>(obj);
            }
        }
    }
}
