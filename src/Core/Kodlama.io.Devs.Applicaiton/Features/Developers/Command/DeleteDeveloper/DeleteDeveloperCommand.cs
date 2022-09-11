using Kodlama.io.Devs.Applicaiton.Services.Repositories;
using Kodlama.io.Devs.Domain.Entities;
using MediatR;

namespace Kodlama.io.Devs.Applicaiton.Features.Developers.Command.DeleteDeveloper
{
    public class DeleteDeveloperCommand : IRequest<bool>
    {
        public Guid Id { get; set; }

        public class DeleteDeveloperCommandHandler : IRequestHandler<DeleteDeveloperCommand, bool>
        {
            private readonly IDeveloperRepository _developerRepository;

            public DeleteDeveloperCommandHandler(IDeveloperRepository developerRepository)
            {
                _developerRepository = developerRepository;
            }

            public async Task<bool> Handle(DeleteDeveloperCommand request, CancellationToken cancellationToken)
            {
                Developer? developer = await _developerRepository.GetAsync(x => x.Id == request.Id);
                //todo business

                await _developerRepository.DeleteAsync(developer);
                return true;
            }
        }
    }
}
