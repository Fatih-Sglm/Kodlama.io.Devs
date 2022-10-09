using AutoMapper;
using Core.Security.Dtos;
using Kodlama.io.Devs.Applicaiton.Abstractions.Repositories;
using Kodlama.io.Devs.Domain.Entities;
using MediatR;

namespace Kodlama.io.Devs.Applicaiton.Features.Users.Developers.Command.UpdateDeveloper
{
    public class UpdateDeveloperCommand : UserForRegisterDto, IRequest<bool>
    {
        public Guid Id { get; set; }
        public class UpdateDeleteCommandHandler : IRequestHandler<UpdateDeveloperCommand, bool>
        {
            private readonly IDeveloperRepository _developerRepository;
            private readonly IMapper _mapper;

            public UpdateDeleteCommandHandler(IDeveloperRepository developerRepository, IMapper mapper)
            {
                _developerRepository = developerRepository;
                _mapper = mapper;
            }

            public async Task<bool> Handle(UpdateDeveloperCommand request, CancellationToken cancellationToken)
            {
                Developer? developer = await _developerRepository.GetAsync(x => x.Id == request.Id);
                //todo business

                await _developerRepository.UpdateAsync(_mapper.Map(request, developer));
                return true;
            }
        }
    }
}
