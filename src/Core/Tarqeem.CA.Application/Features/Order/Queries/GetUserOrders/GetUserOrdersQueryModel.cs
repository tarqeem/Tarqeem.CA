using Mediator;
using Tarqeem.CA.Application.Models.Common;

namespace Tarqeem.CA.Application.Features.Order.Queries.GetUserOrders;

public record GetUserOrdersQueryModel(int UserId) : IRequest<OperationResult<List<GetUsersQueryResultModel>>>;