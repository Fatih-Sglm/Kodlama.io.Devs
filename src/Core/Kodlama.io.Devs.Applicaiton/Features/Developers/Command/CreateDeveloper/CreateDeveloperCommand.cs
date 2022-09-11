using AutoMapper;
using Core.Security.Dtos;
using Core.Security.Hashing;
using Kodlama.io.Devs.Applicaiton.Services.Repositories;
using Kodlama.io.Devs.Domain.Entities;
using MediatR;

namespace Kodlama.io.Devs.Applicaiton.Features.Developers.Command.CreateDeveloper
{
    public class CreateDeveloperCommand : UserForRegisterDto, IRequest<bool>
    {
        public class CreateDeveloperCommandHandler : IRequestHandler<CreateDeveloperCommand, bool>
        {
            private readonly IDeveloperRepository _developerRepository;
            private readonly IMapper _mapper;

            public CreateDeveloperCommandHandler(IDeveloperRepository developerRepository, IMapper mapper)
            {
                _developerRepository = developerRepository;
                _mapper = mapper;
            }

            public async Task<bool> Handle(CreateDeveloperCommand request, CancellationToken cancellationToken)
            {
                var developer = _mapper.Map<Developer>(request);
                HashingHelper.CreatePasswordHash(request.Password, out byte[] passwordHash, out byte[] passwordSalt);
                developer.PasswordHash = passwordHash;
                developer.PasswordSalt = passwordSalt;
                await _developerRepository.AddAsync(developer);
                return true;
            }
        }
    }
}
