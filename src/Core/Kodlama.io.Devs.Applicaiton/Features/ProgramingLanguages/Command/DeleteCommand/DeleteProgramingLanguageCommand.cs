using Kodlama.io.Devs.Applicaiton.Abstractions.Services;
using MediatR;

namespace Kodlama.io.Devs.Applicaiton.Features.ProgramingLanguages.Command.DeleteCommand
{
    public class DeleteProgramingLanguageCommand : IRequest<bool>
    {
        public string Id { get; set; }
    }
    public class DeleteProgramingLanguageCommandHandler : IRequestHandler<DeleteProgramingLanguageCommand, bool>
    {
        private readonly IProgramingLanguageService _programingLanguageService;

        public DeleteProgramingLanguageCommandHandler(IProgramingLanguageService programingLanguageService)
        {
            _programingLanguageService = programingLanguageService;
        }

        public async Task<bool> Handle(DeleteProgramingLanguageCommand request, CancellationToken cancellationToken)
        {
            await _programingLanguageService.Delete(request);
            return true;
        }
    }
}
