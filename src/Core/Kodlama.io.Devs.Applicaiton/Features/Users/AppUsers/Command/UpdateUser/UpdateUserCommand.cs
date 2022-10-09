using AutoMapper;
using Kodlama.io.Devs.Applicaiton.Abstractions.Repositories;
using Kodlama.io.Devs.Applicaiton.Features.Users.Rules;
using MediatR;

namespace Kodlama.io.Devs.Applicaiton.Features.Users.AppUsers.Command.UpdateUser
{
    public class UpdateUserCommand : IRequest<bool>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public Guid Id { get; set; }

        public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, bool>
        {
            private readonly IAppUserRepository _appUserRepository;
            private readonly IMapper _mapper;
            private readonly UserBusinessRules _appUserBusinessRules;

            public UpdateUserCommandHandler(IAppUserRepository appUserRepository, IMapper mapper, UserBusinessRules appUserBusinessRules)
            {
                _appUserRepository = appUserRepository;
                _mapper = mapper;
                _appUserBusinessRules = appUserBusinessRules;
            }

            public async Task<bool> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
            {
                var user = await _appUserRepository.GetAsync(x => x.Id == request.Id);
                await _appUserBusinessRules.CannotBeNull(user);
                await _appUserRepository.UpdateAsync(_mapper.Map(request, user));
                return true;
            }
        }
    }
}
