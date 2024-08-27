using Mediator;
using Tarqeem.CA.Application.Models.Common;

namespace Tarqeem.CA.Application.Features.Order.Commands;

public record DeleteUserOrdersCommand(int UserId):IRequest<OperationResult<bool>>;