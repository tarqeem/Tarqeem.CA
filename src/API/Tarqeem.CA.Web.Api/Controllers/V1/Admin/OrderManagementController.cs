﻿using Tarqeem.CA.Infrastructure.Identity.Identity.PermissionManager;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using Asp.Versioning;
using Tarqeem.CA.Application.Features.Order.Queries.GetAllOrders;
using Tarqeem.CA.WebFramework.BaseController;
using Tarqeem.CA.WebFramework.WebExtensions;
using Mediator;

namespace Tarqeem.CA.Web.Api.Controllers.V1.Admin
{
    [ApiVersion("1")]
    [ApiController]
    [Route("api/v{version:apiVersion}/OrderManagement")]
    [Display(Description= "Managing Users related Orders")]
    [Authorize(ConstantPolicies.DynamicPermission)]
    public class OrderManagementController : BaseController
    {
        private readonly ISender _sender;

        public OrderManagementController(ISender sender)
        {
            _sender = sender;
        }

        [HttpGet("OrderList")]
        public async Task<IActionResult> GetOrders()
        {
            var queryResult = await _sender.Send(new GetAllOrdersQuery());

            return base.OperationResult(queryResult);
        }
    }
}
