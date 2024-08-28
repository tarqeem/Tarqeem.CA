using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mediator;
using Tarqeem.CA.Application.Contracts.Identity;
using Tarqeem.CA.Application.Models.Common;

namespace Tarqeem.CA.Application.Features.Users.Commands.RequestLogout
{
    internal class RequestLogoutCommandHandler:IRequestHandler<RequestLogoutCommand,OperationResult<bool>>
    {
        private readonly IAppUserManager _userManager;

        public RequestLogoutCommandHandler(IAppUserManager userManager)
        {
            _userManager = userManager;
        }

        public async ValueTask<OperationResult<bool>> Handle(RequestLogoutCommand request, CancellationToken cancellationToken)
        {
            var user = await _userManager.GetUserByIdAsync(request.UserId);

            if (user == null) 
                return OperationResult<bool>.FailureResult("User not found");

            await _userManager.UpdateSecurityStampAsync(user);

            return OperationResult<bool>.SuccessResult(true);
        }
    }
}
