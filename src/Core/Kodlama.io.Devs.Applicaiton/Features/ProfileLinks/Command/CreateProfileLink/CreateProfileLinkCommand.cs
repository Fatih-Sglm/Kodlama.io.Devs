using AutoMapper;
using Core.Application.Pipelines.Authorization;
using Kodlama.io.Devs.Applicaiton.Services.Repositories;
using Kodlama.io.Devs.Domain.Entities;
using MediatR;

namespace Kodlama.io.Devs.Applicaiton.Features.ProfileLinks.Command.CreateProfileLink
{
    public class CreateProfileLinkCommand : IRequest<bool>, ISecuredRequest
    {
        public Guid ProfileTypeId { get; set; }
        public string ProfileUrl { get; set; }
        public Guid? AppUserId { get; set; }

        public string[] Roles => throw new NotImplementedException();

        public class CreateProfileLinkCommandHandler : IRequestHandler<CreateProfileLinkCommand, bool>
        {
            private readonly IMapper _mapper;
            private readonly IProfileLinksRepository _profileLinksRepository;

            public CreateProfileLinkCommandHandler(IMapper mapper, IProfileLinksRepository profileLinksRepository)
            {
                _mapper = mapper;
                _profileLinksRepository = profileLinksRepository;
            }

            public async Task<bool> Handle(CreateProfileLinkCommand request, CancellationToken cancellationToken)
            {
                await _profileLinksRepository.AddAsync(_mapper.Map<ProfileLink>(request));
                return true;
            }
        }
    }
}
