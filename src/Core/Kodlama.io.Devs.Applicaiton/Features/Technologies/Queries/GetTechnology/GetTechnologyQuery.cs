using AutoMapper;
using Kodlama.io.Devs.Applicaiton.Abstractions.Repositories;
using Kodlama.io.Devs.Applicaiton.Features.Technologies.Dtos;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Kodlama.io.Devs.Applicaiton.Features.Technologies.Queries.GetTechnology
{
    public class GetTechnologyQuery : IRequest<GetTechnologyDto>
    {
        public Guid Id { get; set; }

        public class GetTechnologyQueryHandler : IRequestHandler<GetTechnologyQuery, GetTechnologyDto>
        {
            private readonly IMapper _mapper;
            private readonly ITechnologyRepository _technologyRepository;

            public GetTechnologyQueryHandler(IMapper mapper, ITechnologyRepository technologyRepository)
            {
                _mapper = mapper;
                _technologyRepository = technologyRepository;
            }
            public async Task<GetTechnologyDto> Handle(GetTechnologyQuery request, CancellationToken cancellationToken)
            {
                var value = await _technologyRepository.GetAsync(x => x.Id == request.Id, include: m => m.Include(x => x.ProgramingLanguage));
                return _mapper.Map<GetTechnologyDto>(value);
            }
        }
    }
}
