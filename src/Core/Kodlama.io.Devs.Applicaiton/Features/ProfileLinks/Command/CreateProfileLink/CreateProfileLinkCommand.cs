using AutoMapper;
using Core.Application.Pipelines.Authorization;
using Core.Security.Extensions;
using Kodlama.io.Devs.Applicaiton.Features.ProfileLinks.Rules;
using Kodlama.io.Devs.Applicaiton.Services.Repositories;
using Kodlama.io.Devs.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Kodlama.io.Devs.Applicaiton.Features.ProfileLinks.Command.CreateProfileLink
{
    public class CreateProfileLinkCommand : IRequest<bool>, ISecuredRequest
    {
        public Guid ProfileTypeId { get; set; }
        public string ProfileUrl { get; set; }

        public string[] Roles => new string[] { "admin", "user" };

        public class CreateProfileLinkCommandHandler : IRequestHandler<CreateProfileLinkCommand, bool>
        {
            private readonly IMapper _mapper;
            private readonly IProfileLinksRepository _profileLinksRepository;
            private readonly IHttpContextAccessor _httpContextAccessor;
            private readonly ProFileLinksBusinessRules _profileLinksBusinessRules;

            public CreateProfileLinkCommandHandler(IMapper mapper, IProfileLinksRepository profileLinksRepository, IHttpContextAccessor httpContextAccessor, ProFileLinksBusinessRules profileLinksBusinessRules)
            {
                _mapper = mapper;
                _profileLinksRepository = profileLinksRepository;
                _httpContextAccessor = httpContextAccessor;
                _profileLinksBusinessRules = profileLinksBusinessRules;
            }

            public async Task<bool> Handle(CreateProfileLinkCommand request, CancellationToken cancellationToken)
            {
                await _profileLinksBusinessRules.CanNotDuplicate(request.ProfileUrl);
                ProfileLink profileLink = _mapper.Map<ProfileLink>(request);
                profileLink.DeveloperId = _httpContextAccessor.HttpContext.User.GetUserId();
                await _profileLinksRepository.AddAsync(profileLink);
                return true;
            }
        }
    }
}
