using Carter;
using Tarqeem.CA.Application.Features.Users.Commands.Create;
using Tarqeem.CA.WebFramework.WebExtensions;
using Mediator;

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

    }
}