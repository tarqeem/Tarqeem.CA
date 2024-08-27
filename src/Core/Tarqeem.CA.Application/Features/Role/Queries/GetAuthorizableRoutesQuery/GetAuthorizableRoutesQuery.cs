using Mediator;
using Tarqeem.CA.Application.Models.Common;

namespace Tarqeem.CA.Application.Features.Role.Queries.GetAuthorizableRoutesQuery;

public record GetAuthorizableRoutesQuery():IRequest<OperationResult<List<GetAuthorizableRoutesQueryResponse>>>;