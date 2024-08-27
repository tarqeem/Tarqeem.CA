using Mediator;
using Tarqeem.CA.Application.Contracts;
using Tarqeem.CA.Application.Contracts.Identity;
using Tarqeem.CA.Application.Models.Common;
using Tarqeem.CA.Application.Models.Jwt;
using Tarqeem.CA.SharedKernel.Extensions;

namespace Tarqeem.CA.Application.Features.Users.Queries.GenerateUserToken;

internal class GenerateUserTokenQueryHandler : IRequestHandler<GenerateUserTokenQuery, OperationResult<AccessToken>>
{
    private readonly IJwtService _jwtService;
    private readonly IAppUserManager _userManager;


    public GenerateUserTokenQueryHandler(IJwtService jwtService, IAppUserManager userManager)
    {
        _jwtService = jwtService;
        _userManager = userManager;
    }

    public async ValueTask<OperationResult<AccessToken>> Handle(GenerateUserTokenQuery request, CancellationToken cancellationToken)
    {
        var user = await _userManager.GetUserByCode(request.UserKey);

        if (user is null)
            return OperationResult<AccessToken>.FailureResult("User Not found");

        var result = user.PhoneNumberConfirmed? await _userManager.VerifyUserCode(
            user, request.Code):await _userManager.ChangePhoneNumber(user,user.PhoneNumber,request.Code);


        if (!result.Succeeded)
            return OperationResult<AccessToken>.FailureResult(result.Errors.StringifyIdentityResultErrors());

        await _userManager.UpdateUserAsync(user);

        var token = await _jwtService.GenerateAsync(user);

        return OperationResult<AccessToken>.SuccessResult(token);
    }
}