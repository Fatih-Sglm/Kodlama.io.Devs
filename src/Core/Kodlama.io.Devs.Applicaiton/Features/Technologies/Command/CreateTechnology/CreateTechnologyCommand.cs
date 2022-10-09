using Kodlama.io.Devs.Applicaiton.Abstractions.Services;
using MediatR;

namespace Kodlama.io.Devs.Applicaiton.Features.Technologies.Command.CreateTechnology
{
    public class CreateTechnologyCommand : IRequest<bool>
    {

        public string Name { get; set; }
        public Guid ProgramingLanguageId { get; set; }

        public class CreateTechnologyCommandHandler : IRequestHandler<CreateTechnologyCommand, bool>
        {
            private readonly ITechnologyService _technologyService;

            public CreateTechnologyCommandHandler(ITechnologyService technologyService)
            {
                _technologyService = technologyService;
            }

            public async Task<bool> Handle(CreateTechnologyCommand request, CancellationToken cancellationToken)
            {
                await _technologyService.Create(request);
                return true;
            }
        }
    }
}
