using Core.Application.Pipelines.Authorization;
using Core.Application.Requests;
using Kodlama.io.Devs.Applicaiton.Abstractions.Services;
using Kodlama.io.Devs.Applicaiton.Features.ProgramingLanguages.Models;
using MediatR;

namespace Kodlama.io.Devs.Applicaiton.Features.ProgramingLanguages.Queries.GetListProgramingLanguage
{

    public class GetListProgramingLanguageQuery : IRequest<PLListModel>, ISecuredRequest
    {
        public PageRequest? PageRequest { get; set; }
        public string[] Roles { get; } = new[] { nameof(GetListProgramingLanguageQuery) };

        public class GetListBrandQueryHandler : IRequestHandler<GetListProgramingLanguageQuery, PLListModel>
        {
            private readonly IProgramingLanguageService _programingLanguageService;

            public GetListBrandQueryHandler(IProgramingLanguageService programingLanguageService)
            {
                _programingLanguageService = programingLanguageService;
            }

            public async Task<PLListModel> Handle(GetListProgramingLanguageQuery request, CancellationToken cancellationToken)
            {
                return await _programingLanguageService.Get(request);
            }
        }
    }

}
