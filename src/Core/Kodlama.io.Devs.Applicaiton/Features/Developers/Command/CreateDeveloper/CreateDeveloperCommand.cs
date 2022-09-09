using Core.Security.Dtos;
using Core.Security.JWT;
using MediatR;

namespace Kodlama.io.Devs.Applicaiton.Features.Developers.Command.CreateDeveloper
{
    public class CreateDeveloperCommand : UserForRegisterDto, IRequest<AccessToken>
    {
        //public CreateProfileLinkCommand CreateProfileLinkCommand { get; set; }
        //public string GithubProfileLink { get; set; }
        //public class CreateDeveloperCommandHandler : IRequestHandler<CreateDeveloperCommand, AccessToken>
        //{
        //    private readonly IUserRepository _developerRepository;
        //    private readonly IMapper _mapper;
        //    private readonly ITokenHelper _tokenHelper;
        //    private readonly IMediator _mediator;

        //    public CreateDeveloperCommandHandler(IUserRepository developerRepository, IMapper mapper, ITokenHelper tokenHelper, IMediator mediator)
        //    {
        //        _developerRepository = developerRepository;
        //        _mapper = mapper;
        //        _tokenHelper = tokenHelper;
        //        _mediator = mediator;
        //    }

        //    public async Task<AccessToken> Handle(CreateDeveloperCommand request, CancellationToken cancellationToken)
        //    {
        //        var developer = _mapper.Map<Developer>(request);
        //        HashingHelper.CreatePasswordHash(request.Password, out byte[] passwordHash, out byte[] passwordSalt);
        //        developer.PasswordHash = passwordHash;
        //        developer.PasswordSalt = passwordSalt;
        //        developer = await _developerRepository.AddAsync(developer);
        //        //await _mediator.Send(request.CreateProfileLinkCommand);
        //        return _tokenHelper.CreateToken(developer, new List<OperationClaim>() { });
        //    }
        //}
    }
}
