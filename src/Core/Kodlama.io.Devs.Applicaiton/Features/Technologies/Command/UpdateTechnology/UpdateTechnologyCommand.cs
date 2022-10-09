using AutoMapper;
using Kodlama.io.Devs.Applicaiton.Abstractions.Repositories;
using MediatR;

namespace Kodlama.io.Devs.Applicaiton.Features.Technologies.Command.UpdateTechnology
{
    public class UpdateTechnologyCommand : IRequest<bool>
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public Guid ProgramingLanguageId { get; set; }

        public class UpdateTechnologyCommandHandler : IRequestHandler<UpdateTechnologyCommand, bool>
        {
            private readonly IMapper _mapper;
            private readonly ITechnologyRepository _technologyRepository;

            public UpdateTechnologyCommandHandler(IMapper mapper, ITechnologyRepository technologyRepository)
            {
                _mapper = mapper;
                _technologyRepository = technologyRepository;
            }



            public async Task<bool> Handle(UpdateTechnologyCommand request, CancellationToken cancellationToken)
            {
                var value = await _technologyRepository.GetAsync(x => x.Id == request.Id);
                await _technologyRepository.UpdateAsync(_mapper.Map(request, value));
                return true;
            }
        }
    }
}
