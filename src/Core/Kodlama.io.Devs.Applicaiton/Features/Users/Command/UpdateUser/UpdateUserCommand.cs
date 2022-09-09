using AutoMapper;
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
            private readonly IUserRepository _userRepository;
            private readonly IMapper _mapper;

            public UpdateUserCommandHandler(IUserRepository userRepository, IMapper mapper)
            {
                _userRepository = userRepository;
                _mapper = mapper;
            }

            public async Task<bool> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
            {
                var user = await _userRepository.GetAsync(x => x.Id == request.Id);
                await _userRepository.UpdateAsync(_mapper.Map(request, user));
                return true;
            }
        }
    }
}
