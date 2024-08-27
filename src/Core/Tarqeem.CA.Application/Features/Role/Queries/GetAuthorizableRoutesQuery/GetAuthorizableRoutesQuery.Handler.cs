using Mediator;
using Tarqeem.CA.Application.Contracts.Identity;
using Tarqeem.CA.Application.Models.Common;

namespace Tarqeem.CA.Application.Features.Role.Queries.GetAuthorizableRoutesQuery
{
    internal class GetAuthorizableRoutesQueryHandler:IRequestHandler<GetAuthorizableRoutesQuery,OperationResult<List<GetAuthorizableRoutesQueryResponse>>>
    {
        private readonly IRoleManagerService _roleManagerService;

        public GetAuthorizableRoutesQueryHandler(IRoleManagerService roleManagerService)
        {
            _roleManagerService = roleManagerService;
        }

        public async ValueTask<OperationResult<List<GetAuthorizableRoutesQueryResponse>>> Handle(GetAuthorizableRoutesQuery request, CancellationToken cancellationToken)
        {
            var authRoutes = await _roleManagerService.GetPermissionActionsAsync();

            if(!authRoutes.Any())
                return OperationResult<List<GetAuthorizableRoutesQueryResponse>>.NotFoundResult("No Special auth route found");

            var result = authRoutes.Select(c =>
                    new GetAuthorizableRoutesQueryResponse(c.Key, c.AreaName, c.ControllerName, c.ActionName,c.ControllerDescription))
                .ToList();

            return OperationResult<List<GetAuthorizableRoutesQueryResponse>>.SuccessResult(result);
        }
    }
}
