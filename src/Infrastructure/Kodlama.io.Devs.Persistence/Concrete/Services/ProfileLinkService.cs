using AutoMapper;
using Core.Persistence.Paging;
using Core.Security.Extensions;
using Kodlama.io.Devs.Applicaiton.Abstractions.Repositories;
using Kodlama.io.Devs.Applicaiton.Abstractions.Services;
using Kodlama.io.Devs.Applicaiton.Features.ProfileLinks.Command.CreateProfileLink;
using Kodlama.io.Devs.Applicaiton.Features.ProfileLinks.Command.DeleteProfileLink;
using Kodlama.io.Devs.Applicaiton.Features.ProfileLinks.Command.UpdateProfileLink;
using Kodlama.io.Devs.Applicaiton.Features.ProfileLinks.Dtos;
using Kodlama.io.Devs.Applicaiton.Features.ProfileLinks.Models;
using Kodlama.io.Devs.Applicaiton.Features.ProfileLinks.Queries.GetListProfileLink;
using Kodlama.io.Devs.Applicaiton.Features.ProfileLinks.Queries.GetProfileLink;
using Kodlama.io.Devs.Applicaiton.Features.ProfileLinks.Rules;
using Kodlama.io.Devs.Domain.Entities;
using Microsoft.AspNetCore.Http;

namespace Kodlama.io.Devs.Persistence.Concrete.Services
{
    public class ProfileLinkService : IProfileLinkService
    {
        private readonly IProfileLinksRepository _profileLinksRepository;
        private readonly ProFileLinksBusinessRules _proFileLinksBusinessRules;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IUserRepository _userRepository;
        private readonly IUserService _userService;
        public ProfileLinkService(IProfileLinksRepository profileLinksRepository, IMapper mapper, ProFileLinksBusinessRules proFileLinksBusinessRules, IHttpContextAccessor httpContextAccessor, IUserRepository userRepository, IUserService userService)
        {
            _profileLinksRepository = profileLinksRepository;
            _mapper = mapper;
            _proFileLinksBusinessRules = proFileLinksBusinessRules;
            _httpContextAccessor = httpContextAccessor;
            _userRepository = userRepository;
            _userService = userService;
        }

        public async Task Create(CreateProfileLinkCommand command)
        {
            await _proFileLinksBusinessRules.CanNotDuplicate(command.ProfileUrl);
            await _profileLinksRepository.AddAsync(_mapper.Map<ProfileLink>(command));
        }

        public async Task Delete(DeleteProfileLinkCommand command)
        {
            ProfileLink? value = await _profileLinksRepository.GetAsync(x => x.Id == command.Id);
            await _proFileLinksBusinessRules.CannotBeNull(value);
            await _profileLinksRepository.DeleteAsync(value);
        }

        public async Task<GetListProfileLinkModel> Get(GetListProfileLinkQuery query)
        {
            Guid userId = _httpContextAccessor.HttpContext.User.GetUserId();
            var value = await _userService.GetUserRole(new() { UserId = userId });
            IPaginate<ProfileLink> obj = null;
            if (value.Roles.Any(x => x.Name != "Admin"))
                obj = await _profileLinksRepository.GetListAsync(x => x.DeveloperId == userId, index: query.PageRequest.Page, size: query.PageRequest.PageSize);
            obj = await _profileLinksRepository.GetListAsync(index: query.PageRequest.Page, size: query.PageRequest.PageSize);
            return _mapper.Map<GetListProfileLinkModel>(obj);
        }

        public async Task<GetProfileLinkDto> GetById(GetProfileLinkQuery query)
        {
            ProfileLink? profileLink = await _profileLinksRepository.GetAsync(x => x.Id == query.Id);
            await _proFileLinksBusinessRules.CannotBeNull(profileLink);
            return _mapper.Map<GetProfileLinkDto>(profileLink);
        }

        public async Task Update(UpdateProfileLinkCommand command)
        {
            ProfileLink? profile = await _profileLinksRepository.GetAsync(x => x.Id == command.Id);
            await _proFileLinksBusinessRules.CannotBeNull(profile);
            await _profileLinksRepository.UpdateAsync(_mapper.Map(command, profile));
        }
    }
}
