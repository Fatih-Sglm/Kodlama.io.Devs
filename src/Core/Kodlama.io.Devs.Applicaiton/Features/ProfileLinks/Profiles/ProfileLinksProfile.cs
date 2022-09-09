using AutoMapper;
using Core.Persistence.Paging;
using Kodlama.io.Devs.Applicaiton.Features.ProfileLinks.Command.CreateProfileLink;
using Kodlama.io.Devs.Applicaiton.Features.ProfileLinks.Command.UpdateProfileLink;
using Kodlama.io.Devs.Applicaiton.Features.ProfileLinks.Dtos;
using Kodlama.io.Devs.Applicaiton.Features.ProfileLinks.Models;
using Kodlama.io.Devs.Domain.Entities;

namespace Kodlama.io.Devs.Applicaiton.Features.ProfileLinks.Profiles
{
    public class ProfileLinksProfile : Profile
    {
        public ProfileLinksProfile()
        {
            CreateMap<CreateProfileLinkCommand, ProfileLink>();
            CreateMap<UpdateProfileLinkCommand, ProfileLink>();
            CreateMap<IPaginate<ProfileLink>, GetListProfileLinkModel>();
            CreateMap<ProfileLink, GetProfileLinkDto>();
        }
    }
}
