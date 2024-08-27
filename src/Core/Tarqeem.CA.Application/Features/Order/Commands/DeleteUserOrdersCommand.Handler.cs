using Mediator;
using Tarqeem.CA.Application.Contracts.Persistence;
using Tarqeem.CA.Application.Models.Common;

namespace Tarqeem.CA.Application.Features.Order.Commands;

public class DeleteUserOrdersCommandHandler(IUnitOfWork unitOfWork) : IRequestHandler<DeleteUserOrdersCommand,OperationResult<bool>>
{
    public async ValueTask<OperationResult<bool>> Handle(DeleteUserOrdersCommand request, CancellationToken cancellationToken)
    {
        await unitOfWork.OrderRepository.DeleteUserOrdersAsync(request.UserId);

        return OperationResult<bool>.SuccessResult(true);
    }
}