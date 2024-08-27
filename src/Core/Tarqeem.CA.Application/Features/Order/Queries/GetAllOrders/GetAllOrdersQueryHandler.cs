using Mediator;
using Tarqeem.CA.Application.Contracts.Persistence;
using Tarqeem.CA.Application.Models.Common;

namespace Tarqeem.CA.Application.Features.Order.Queries.GetAllOrders
{
    internal class GetAllOrdersQueryHandler:IRequestHandler<GetAllOrdersQuery,OperationResult<List<GetAllOrdersQueryResult>>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetAllOrdersQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async ValueTask<OperationResult<List<GetAllOrdersQueryResult>>> Handle(GetAllOrdersQuery request, CancellationToken cancellationToken)
        {
            var orders = await _unitOfWork.OrderRepository.GetAllOrdersWithRelatedUserAsync();

            var result = orders.Select(c => new GetAllOrdersQueryResult(c.Id, c.OrderName, c.UserId, c.User.UserName)).ToList();

            return OperationResult<List<GetAllOrdersQueryResult>>.SuccessResult(result);
        }
    }
}
