using AutoMapper;
using Kodlama.io.Devs.Applicaiton.Features.ProfileLinks.Rules;
using Kodlama.io.Devs.Applicaiton.Services.Repositories;
using Kodlama.io.Devs.Domain.Entities;
using MediatR;

namespace Kodlama.io.Devs.Applicaiton.Features.ProfileLinks.Command.UpdateProfileLink
{
    public class UpdateProfileLinkCommand : IRequest<bool>
    {
        public Guid Id { get; set; }
        public Guid ProfileTypeId { get; set; }
        public string ProfileUrl { get; set; }

        public class UpdateProfileLinkCommandHandler : IRequestHandler<UpdateProfileLinkCommand, bool>
        {
            public readonly IMapper _mapper;
            private readonly IProfileLinksRepository _profileLinksRepository;
            private readonly ProFileLinksBusinessRules _proFileLinksBusinessRules;

            public UpdateProfileLinkCommandHandler(IMapper mapper, IProfileLinksRepository profileLinksRepository, ProFileLinksBusinessRules proFileLinksBusinessRules)
            {
                _mapper = mapper;
                _profileLinksRepository = profileLinksRepository;
                _proFileLinksBusinessRules = proFileLinksBusinessRules;
            }

            public async Task<bool> Handle(UpdateProfileLinkCommand request, CancellationToken cancellationToken)
            {
                ProfileLink? profile = await _profileLinksRepository.GetAsync(x => x.Id == request.Id);
                await _proFileLinksBusinessRules.CannotBeNull(profile);
                await _profileLinksRepository.UpdateAsync(_mapper.Map(request, profile));
                return true;
            }
        }
    }
}
