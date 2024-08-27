using Mediator;
using Tarqeem.CA.Application.Models.Common;

namespace Tarqeem.CA.Application.Features.Role.Commands.UpdateRoleClaimsCommand;

public record UpdateRoleClaimsCommand( int RoleId, List<string> RoleClaimValue):IRequest<OperationResult<bool>>;