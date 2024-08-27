using Mediator;
using Tarqeem.CA.Application.Models.Common;

namespace Tarqeem.CA.Application.Features.Order.Queries.GetAllOrders;

public record GetAllOrdersQuery():IRequest<OperationResult<List<GetAllOrdersQueryResult>>>;