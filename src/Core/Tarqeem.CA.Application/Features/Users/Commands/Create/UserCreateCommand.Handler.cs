using AutoMapper;
using Tarqeem.CA.Domain.Entities.User;
using Mediator;
using Microsoft.Extensions.Logging;
using Tarqeem.CA.Application.Contracts;
using Tarqeem.CA.Application.Contracts.Identity;
using Tarqeem.CA.Application.Models.Common;
using Tarqeem.CA.Application.Models.Jwt;

namespace Tarqeem.CA.Application.Features.Users.Commands.Create;

internal class UserCreateCommandHandler : IRequestHandler<UserCreateCommand, OperationResult<AccessToken>>
{
    private readonly IAppUserManager _userManager;
    private readonly IMapper _mapper;
    private readonly IJwtService _jwtService;

    public UserCreateCommandHandler(IAppUserManager userRepository, ILogger<UserCreateCommandHandler> logger,
        IMapper mapper, IJwtService jwtService)
    {
        _userManager = userRepository;
        _mapper = mapper;
        _jwtService = jwtService;
    }

    public async ValueTask<OperationResult<AccessToken>> Handle(UserCreateCommand request,
        CancellationToken cancellationToken)
    {
        var userNameExist = await _userManager.IsExistUser(request.UserName);

        if (userNameExist)
            return OperationResult<AccessToken>.FailureResult("Username already exists");

        var user = _mapper.Map<User>(request);

        var createResult = await _userManager.CreateUserWithPasswordAsync(user, request.Password);

        if (!createResult.Succeeded)
        {
            return OperationResult<AccessToken>.FailureResult(string.Join(",",
                createResult.Errors.Select(c => c.Description)));
        }

        var token = await _jwtService.GenerateAsync(user);
        return OperationResult<AccessToken>.SuccessResult(token);
    }
}