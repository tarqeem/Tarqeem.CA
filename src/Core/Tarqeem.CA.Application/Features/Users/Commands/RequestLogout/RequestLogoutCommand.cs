using Mediator;
using Tarqeem.CA.Application.Models.Common;

namespace Tarqeem.CA.Application.Features.Users.Commands.RequestLogout;

public record RequestLogoutCommand(int UserId):IRequest<OperationResult<bool>>;