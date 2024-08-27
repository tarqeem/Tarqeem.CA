using Mediator;
using Tarqeem.CA.Application.Contracts.Identity;
using Tarqeem.CA.Application.Models.Common;

namespace Tarqeem.CA.Application.Features.Role.Queries.GetAllRolesQuery
{
    internal class GetAllRolesQueryHandler:IRequestHandler<GetAllRolesQuery,OperationResult<List<GetAllRolesQueryResponse>>>
    {
        private readonly IRoleManagerService _roleManagerService;

        public GetAllRolesQueryHandler(IRoleManagerService roleManagerService)
        {
            _roleManagerService = roleManagerService;
        }

        public async ValueTask<OperationResult<List<GetAllRolesQueryResponse>>> Handle(GetAllRolesQuery request, CancellationToken cancellationToken)
        {
            var roles = await _roleManagerService.GetRolesAsync();

            if(!roles.Any())
                return OperationResult<List<GetAllRolesQueryResponse>>.NotFoundResult("No Roles Found");

            var result = roles.Select(c => new GetAllRolesQueryResponse(int.Parse(c.Id), c.Name)).ToList();

            return OperationResult<List<GetAllRolesQueryResponse>>.SuccessResult(result);
        }
    }
}
