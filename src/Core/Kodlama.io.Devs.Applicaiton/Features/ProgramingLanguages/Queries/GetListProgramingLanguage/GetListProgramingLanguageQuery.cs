using AutoMapper;
using Core.Application.Requests;
using Core.Persistence.Paging;
using Kodlama.io.Devs.Applicaiton.Features.ProgramingLanguages.Models;
using Kodlama.io.Devs.Applicaiton.Services.Repositories;
using Kodlama.io.Devs.Domain.Entities;
using MediatR;

namespace Kodlama.io.Devs.Applicaiton.Features.ProgramingLanguages.Queries.GetListProgramingLanguage
{
    public class GetListProgramingLanguageQuery : IRequest<PLListModel>
    {
        public PageRequest PageRequest { get; set; }
        public class GetListBrandQueryHandler : IRequestHandler<GetListProgramingLanguageQuery, PLListModel>
        {
            private readonly IProgramingLanguageRepository _programingLanguageRepository;
            private readonly IMapper _mapper;

            public GetListBrandQueryHandler(IProgramingLanguageRepository programingLanguageRepository, IMapper mapper)
            {
                _programingLanguageRepository = programingLanguageRepository;
                _mapper = mapper;
            }

            public async Task<PLListModel> Handle(GetListProgramingLanguageQuery request, CancellationToken cancellationToken)
            {

                IPaginate<ProgramingLanguage> pl = await _programingLanguageRepository.GetListAsync(index: request.PageRequest.Page, size: request.PageRequest.PageSize);
                var v = _mapper.Map<PLListModel>(pl);
                return v;
            }
        }
    }

}
