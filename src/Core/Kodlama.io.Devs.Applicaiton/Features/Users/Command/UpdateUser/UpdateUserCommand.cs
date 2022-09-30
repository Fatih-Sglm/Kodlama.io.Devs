using AutoMapper;
using Kodlama.io.Devs.Applicaiton.Features.Users.Rules;
using Kodlama.io.Devs.Applicaiton.Services.Repositories;
using MediatR;

namespace Kodlama.io.Devs.Applicaiton.Features.Users.Command.UpdateUser
{
    public class UpdateUserCommand : IRequest<bool>
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }

        public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, bool>
        {
            private readonly IAppUserRepository _appUserRepository;
            private readonly IMapper _mapper;
            private readonly AuthBusinessRules _authBusinessRules;

            public UpdateUserCommandHandler(IAppUserRepository appUserRepository, IMapper mapper, AuthBusinessRules authBusinessRules)
            {
                _appUserRepository = appUserRepository;
                _mapper = mapper;
                _authBusinessRules = authBusinessRules;
            }

            public async Task<bool> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
            {
                var user = await _appUserRepository.GetAsync(x => x.Id == request.Id);
                await _authBusinessRules.UserCannotBeNull(user);
                await _appUserRepository.UpdateAsync(_mapper.Map(request, user));
                return true;
            }
        }
    }
}
