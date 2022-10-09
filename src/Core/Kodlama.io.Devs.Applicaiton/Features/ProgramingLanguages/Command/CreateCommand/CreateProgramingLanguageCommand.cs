using Core.Application.Pipelines.Authorization;
using Kodlama.io.Devs.Applicaiton.Abstractions.Services;
using MediatR;

namespace Kodlama.io.Devs.Applicaiton.Features.ProgramingLanguages.Command.CreateCommand
{
    public class CreateProgramingLanguageCommand : IRequest<bool>, ISecuredRequest
    {
        public string Name { get; set; }

        public string[] Roles => new[] { nameof(CreateProgramingLanguageCommand) };

        public class CreateProgramingLanguageCommandHandler : IRequestHandler<CreateProgramingLanguageCommand, bool>
        {
            private readonly IProgramingLanguageService _programingLanguageService;

            public CreateProgramingLanguageCommandHandler(IProgramingLanguageService programingLanguageService)
            {
                _programingLanguageService = programingLanguageService;
            }



            public async Task<bool> Handle(CreateProgramingLanguageCommand request, CancellationToken cancellationToken)
            {
                await _programingLanguageService.Create(request);
                return true;
            }
        }
    }
}
