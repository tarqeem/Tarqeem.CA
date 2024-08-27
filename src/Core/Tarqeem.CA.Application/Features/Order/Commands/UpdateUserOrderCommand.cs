using System.Text.Json.Serialization;
using FluentValidation;
using Mediator;
using Tarqeem.CA.Application.Models.Common;
using Tarqeem.CA.SharedKernel.ValidationBase;
using Tarqeem.CA.SharedKernel.ValidationBase.Contracts;

namespace Tarqeem.CA.Application.Features.Order.Commands;

public record UpdateUserOrderCommand
    (int OrderId, string OrderName) : IRequest<OperationResult<bool>>,IValidatableModel<UpdateUserOrderCommand>
{
    [JsonIgnore]
    public int UserId { get; set; }

    public IValidator<UpdateUserOrderCommand> ValidateApplicationModel(ApplicationBaseValidationModelProvider<UpdateUserOrderCommand> validator)
    {
        validator.RuleFor(c => c.OrderId).NotEmpty().GreaterThan(0);
        validator.RuleFor(c => c.OrderName).NotEmpty().NotNull();

        return validator;
    }
};