using AutoMapper;
using Core.Security.Dtos;
using Kodlama.io.Devs.Applicaiton.Features.AppUsers.Rules;
using Kodlama.io.Devs.Applicaiton.Services.Repositories;
using MediatR;

namespace Kodlama.io.Devs.Applicaiton.Features.AppUsers.Command.UpdateUser
{
    public class UpdateUserCommand : UserForRegisterDto, IRequest<bool>
    {
        public Guid Id { get; set; }

        public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, bool>
        {
            private readonly IAppUserRepository _appUserRepository;
            private readonly IMapper _mapper;
            private readonly AppUserBusinessRules _appUserBusinessRules;

            public UpdateUserCommandHandler(IAppUserRepository appUserRepository, IMapper mapper, AppUserBusinessRules appUserBusinessRules)
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
