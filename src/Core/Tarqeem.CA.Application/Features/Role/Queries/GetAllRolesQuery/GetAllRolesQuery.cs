using Mediator;
using Tarqeem.CA.Application.Models.Common;

namespace Tarqeem.CA.Application.Features.Role.Queries.GetAllRolesQuery;

public record GetAllRolesQuery():IRequest<OperationResult<List<GetAllRolesQueryResponse>>>;