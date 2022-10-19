using Kodlama.io.Devs.Applicaiton.Abstractions.Repositories;
using Kodlama.io.Devs.Applicaiton.Features.ProfileTypes.Rules;
using MediatR;

namespace Kodlama.io.Devs.Applicaiton.Features.ProfileTypes.Command.CreateProfileType
{
    public class CreateProfileTypeCommand : IRequest<bool>
    {
        public string PrfileTypeName { get; set; }

        public class CreateProfileTypeCommandHandler : IRequestHandler<CreateProfileTypeCommand, bool>
        {

            private readonly IProfileTypeRepository _profileTypeRepository;
            private readonly ProfileTypeBusinessRules _profileTypeBusinessRules;

            public CreateProfileTypeCommandHandler(IProfileTypeRepository profileTypeRepository,
                ProfileTypeBusinessRules profileTypeBusinessRules)
            {
                _profileTypeRepository = profileTypeRepository;
                _profileTypeBusinessRules = profileTypeBusinessRules;
            }

            public async Task<bool> Handle(CreateProfileTypeCommand request, CancellationToken cancellationToken)
            {
                await _profileTypeBusinessRules.CanNotDuplicate(request.PrfileTypeName);
                await _profileTypeRepository.AddAsync(new()
                {
                    PType = request.PrfileTypeName
                });
                return true;
            }
        }
    }
}

