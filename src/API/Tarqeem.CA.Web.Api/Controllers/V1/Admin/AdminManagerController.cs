using Asp.Versioning;
using Tarqeem.CA.Application.Features.Admin.Commands.AddAdminCommand;
using Tarqeem.CA.Application.Features.Admin.Queries.GetToken;
using Tarqeem.CA.WebFramework.BaseController;
using Tarqeem.CA.WebFramework.WebExtensions;
using Mediator;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Tarqeem.CA.Web.Api.Controllers.V1.Admin
{
    [ApiVersion("1")]
    [ApiController]
    [Route("api/v{version:apiVersion}/AdminManager")]
    public class AdminManagerController(ISender sender) : BaseController
    {
        [HttpPost("Login")]
        public async Task<IActionResult> AdminLogin(AdminGetTokenQuery model)
        {
            var query = await sender.Send(model);

            return base.OperationResult(query);
        }

        [Authorize(Roles = "admin")]
        [HttpPost("NewAdmin")]
        public async Task<IActionResult> AddNewAdmin(AddAdminCommand model)
        {
            var commandResult = await sender.Send(model);

            return base.OperationResult(commandResult);
        }
    }
}
