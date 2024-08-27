using Mediator;
using Tarqeem.CA.Application.Models.Common;

namespace Tarqeem.CA.Application.Features.Users.Queries.GetUsers;

public record GetUsersQuery : IRequest<OperationResult<List<GetUsersQueryResponse>>>;