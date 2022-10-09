using Kodlama.io.Devs.Applicaiton.Abstractions.Services;
using MediatR;

namespace Kodlama.io.Devs.Applicaiton.Features.ProgramingLanguages.Command.UpdateCommand
{
    public class UpdateProgramingLanguageCommand : IRequest<bool>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public class UpdateProgramingLanguageCommandHandler : IRequestHandler<UpdateProgramingLanguageCommand, bool>
        {
            private readonly IProgramingLanguageService _programingLanguageService;

            public UpdateProgramingLanguageCommandHandler(IProgramingLanguageService programingLanguageService)
            {
                _programingLanguageService = programingLanguageService;
            }

            public async Task<bool> Handle(UpdateProgramingLanguageCommand request, CancellationToken cancellationToken)
            {
                await _programingLanguageService.Update(request);
                return true;
            }
        }
    }
}
