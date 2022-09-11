using AutoMapper;
using Core.Security.Extensions;
using Kodlama.io.Devs.Applicaiton.Services.Repositories;
using Kodlama.io.Devs.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Kodlama.io.Devs.Applicaiton.Features.ProfileLinks.Command.CreateProfileLink
{
    public class CreateProfileLinkCommand : IRequest<bool>
    {
        public ProfileType ProfileType { get; set; }
        public string ProfileUrl { get; set; }
        public class CreateProfileLinkCommandHandler : IRequestHandler<CreateProfileLinkCommand, bool>
        {
            private readonly IMapper _mapper;
            private readonly IProfileLinksRepository _profileLinksRepository;
            private readonly IHttpContextAccessor _httpContextAccessor;

            public CreateProfileLinkCommandHandler(IMapper mapper, IProfileLinksRepository profileLinksRepository, IHttpContextAccessor httpContextAccessor)
            {
                _mapper = mapper;
                _profileLinksRepository = profileLinksRepository;
                _httpContextAccessor = httpContextAccessor;
            }

            public async Task<bool> Handle(CreateProfileLinkCommand request, CancellationToken cancellationToken)
            {
                ProfileLink profileLink = _mapper.Map<ProfileLink>(request);
                profileLink.AppUserId = _httpContextAccessor.HttpContext.User.GetUserId();
                await _profileLinksRepository.AddAsync(profileLink);
                return true;
            }
        }
    }
}
