using System.Security.Claims;
using Carter;
using Tarqeem.CA.Application.Features.Users.Commands.Create;
using Tarqeem.CA.Application.Features.Users.Commands.RefreshUserTokenCommand;
using Tarqeem.CA.Application.Features.Users.Commands.RequestLogout;
using Tarqeem.CA.Application.Features.Users.Queries.GenerateUserToken;
using Tarqeem.CA.Application.Features.Users.Queries.TokenRequest;
using Tarqeem.CA.SharedKernel.Extensions;
using Tarqeem.CA.WebFramework.WebExtensions;
using Mediator;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc;

namespace Tarqeem.CA.Web.Api.Endpoints;

public class UserEndpoints : ICarterModule
{
    private readonly string _routePrefix= "/api/v{version:apiVersion}/Users/";
    private readonly double _version = 1.1;
    private readonly string _tag ="User";
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapEndpoint(
            builder => builder.MapPost($"{_routePrefix}Register", async (UserCreateCommand model,ISender sender) =>
        {
            var result = await sender.Send(model);
            return result.ToEndpointResult();
        }),_version,"Register",_tag);


        app.MapEndpoint(
            builder => builder.MapPost($"{_routePrefix}TokenRequest", async (UserTokenRequestQuery model, ISender sender) =>
            {
                var result = await sender.Send(model);
                return result.ToEndpointResult();
            }), _version, "TokenRequest", _tag);


        app.MapEndpoint(
            builder => builder.MapPost($"{_routePrefix}LoginConfirmation", async (GenerateUserTokenQuery model, ISender sender) =>
            {
                var result = await sender.Send(model);
                return result.ToEndpointResult();
            }), _version, "LoginConfirmation", _tag);

        app.MapEndpoint(
            builder => builder.MapGet($"{_routePrefix}RefreshSignIn", async ( Guid userRefreshToken, ISender sender) =>
            {

                var result = await sender.Send(new RefreshUserTokenCommand(userRefreshToken));
                return result.ToEndpointResult();
            }), _version, "RefreshSignIn", _tag);

        app.MapEndpoint(
            builder => builder.MapGet($"{_routePrefix}Logout", async (ClaimsPrincipal user, ISender sender) =>
            {

                var result = await sender.Send(new RequestLogoutCommand(int.Parse(user.Identity.GetUserId())));
                return result.ToEndpointResult();
            }), _version, "Logout", _tag)
            .RequireAuthorization();
    }
}