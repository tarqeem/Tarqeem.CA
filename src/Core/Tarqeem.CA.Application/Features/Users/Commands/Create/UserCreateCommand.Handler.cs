using AutoMapper;
using Tarqeem.CA.Domain.Entities.User;
using Mediator;
using Microsoft.Extensions.Logging;
using Tarqeem.CA.Application.Contracts.Identity;
using Tarqeem.CA.Application.Models.Common;

namespace Tarqeem.CA.Application.Features.Users.Commands.Create;

internal class UserCreateCommandHandler : IRequestHandler<UserCreateCommand, OperationResult<UserCreateCommandResult>>
{

    private readonly IAppUserManager _userManager;
    private readonly ILogger<UserCreateCommandHandler> _logger;
    private readonly IMapper _mapper;
    public UserCreateCommandHandler(IAppUserManager userRepository, ILogger<UserCreateCommandHandler> logger, IMapper mapper)
    {
        _userManager = userRepository;
        _logger = logger;
        _mapper = mapper;
    }

    public async ValueTask<OperationResult<UserCreateCommandResult>> Handle(UserCreateCommand request, CancellationToken cancellationToken)
    {
        var userNameExist = await _userManager.IsExistUser(request.UserName);

        if (userNameExist)
            return OperationResult<UserCreateCommandResult>.FailureResult("Username already exists");

        var user = _mapper.Map<User>(request);

        var createResult = await _userManager.CreateUser(user);

        if (!createResult.Succeeded)
        {
            return OperationResult<UserCreateCommandResult>.FailureResult(string.Join(",", createResult.Errors.Select(c => c.Description)));
        }


        return OperationResult<UserCreateCommandResult>.SuccessResult(new UserCreateCommandResult { UserGeneratedKey = user.GeneratedCode });
    }
}
