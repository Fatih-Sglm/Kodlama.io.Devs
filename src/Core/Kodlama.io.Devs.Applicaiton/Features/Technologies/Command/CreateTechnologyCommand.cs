using AutoMapper;
using Kodlama.io.Devs.Applicaiton.Services.Repositories;
using Kodlama.io.Devs.Domain.Entities;
using MediatR;

namespace Kodlama.io.Devs.Applicaiton.Features.Technologies.Command
{
    public class CreateTechnologyCommand : IRequest<bool>
    {

        public string Name { get; set; }
        public Guid ProgramingLanguageId { get; set; }

        public class CreateTechnologyCommandHandler : IRequestHandler<CreateTechnologyCommand, bool>
        {
            private readonly IMapper _mapper;
            private readonly ITechnologyRepository _technologyRepository;

            public CreateTechnologyCommandHandler(IMapper mapper, ITechnologyRepository technologyRepository)
            {
                _mapper = mapper;
                _technologyRepository = technologyRepository;
            }

            public async Task<bool> Handle(CreateTechnologyCommand request, CancellationToken cancellationToken)
            {
                await _technologyRepository.AddAsync(_mapper.Map<Technology>(request));
                return true;
            }
        }
    }
}
