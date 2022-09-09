using AutoMapper;
using Kodlama.io.Devs.Applicaiton.Services.Repositories;
using Kodlama.io.Devs.Domain.Entities;
using MediatR;

namespace Kodlama.io.Devs.Applicaiton.Features.ProfileLinks.Command.UpdateProfileLink
{
    public class UpdateProfileLinkCommand : IRequest<bool>
    {
        public Guid Id { get; set; }
        public ProfileType ProfileType { get; set; }
        public string ProfileUrl { get; set; }

        public class UpdateProfileLinkCommandHandler : IRequestHandler<UpdateProfileLinkCommand, bool>
        {
            public readonly IMapper _mapper;
            private readonly IProfileLinksRepository _profileLinksRepository;

            public UpdateProfileLinkCommandHandler(IMapper mapper, IProfileLinksRepository profileLinksRepository)
            {
                _mapper = mapper;
                _profileLinksRepository = profileLinksRepository;
            }

            public async Task<bool> Handle(UpdateProfileLinkCommand request, CancellationToken cancellationToken)
            {
                ProfileLink profile = await _profileLinksRepository.GetAsync(x => x.Id == request.Id);
                await _profileLinksRepository.UpdateAsync(_mapper.Map(request, profile));
                return true;
            }
        }
    }
}
