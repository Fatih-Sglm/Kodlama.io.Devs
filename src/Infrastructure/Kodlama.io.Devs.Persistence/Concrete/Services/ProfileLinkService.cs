using AutoMapper;
using Core.Persistence.Paging;
using Core.Security.Extensions;
using Kodlama.io.Devs.Applicaiton.Abstractions.Repositories;
using Kodlama.io.Devs.Applicaiton.Abstractions.Services;
using Kodlama.io.Devs.Applicaiton.Features.ProfileLinks.Models;
using Kodlama.io.Devs.Applicaiton.Features.ProfileLinks.Queries.GetListProfileLink;
using Kodlama.io.Devs.Applicaiton.Features.ProfileLinks.Rules;
using Kodlama.io.Devs.Domain.Entities;
using Microsoft.AspNetCore.Http;

namespace Kodlama.io.Devs.Persistence.Concrete.Services
{
    public class ProfileLinkService : IProfileLinkService
    {
        private readonly IProfileLinksRepository _profileLinksRepository;
        private readonly ProfileLinksBusinessRules _proFileLinksBusinessRules;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IUserService _userService;

        public ProfileLinkService(IProfileLinksRepository profileLinksRepository,
            ProfileLinksBusinessRules proFileLinksBusinessRules,
            IMapper mapper, IHttpContextAccessor httpContextAccessor, IUserService userService)
        {
            _profileLinksRepository = profileLinksRepository;
            _proFileLinksBusinessRules = proFileLinksBusinessRules;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
            _userService = userService;
        }

        public async Task<GetListProfileLinkModel> GetUserProfileLinks(GetListProfileLinkQuery query)
        {
            Guid userId = _httpContextAccessor.HttpContext.User.GetUserId();
            var value = await _userService.GetUserRole(new() { UserId = userId });
            IPaginate<ProfileLink> obj = null;
            //todo return the claims role control
            if (value.Roles.Any(x => x.Name != "Admin"))
                obj = await _profileLinksRepository.GetListAsync(x => x.DeveloperId == userId, index: query.PageRequest.Page, size: query.PageRequest.PageSize);
            obj = await _profileLinksRepository.GetListAsync(index: query.PageRequest.Page, size: query.PageRequest.PageSize);
            return _mapper.Map<GetListProfileLinkModel>(obj);
        }
    }
}
