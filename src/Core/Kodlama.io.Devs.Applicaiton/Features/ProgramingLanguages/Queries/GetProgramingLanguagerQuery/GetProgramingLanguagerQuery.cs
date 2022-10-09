using Kodlama.io.Devs.Applicaiton.Abstractions.Services;
using Kodlama.io.Devs.Applicaiton.Features.ProgramingLanguages.Dtos;
using MediatR;

namespace Kodlama.io.Devs.Applicaiton.Features.ProgramingLanguages.Queries.GetProgramingLanguagerQuery
{
    public class GetProgramingLanguagerQuery : IRequest<PLLDto>
    {
        public Guid Id { get; set; }
    }
    public class GetProgramingLanguagerQueryHandler : IRequestHandler<GetProgramingLanguagerQuery, PLLDto>
    {
        private readonly IProgramingLanguageService _programingLanguageService;

        public GetProgramingLanguagerQueryHandler(IProgramingLanguageService programingLanguageService)
        {
            _programingLanguageService = programingLanguageService;
        }
        public async Task<PLLDto> Handle(GetProgramingLanguagerQuery request, CancellationToken cancellationToken)
        {
            return await _programingLanguageService.GetById(request);
        }
    }
}
