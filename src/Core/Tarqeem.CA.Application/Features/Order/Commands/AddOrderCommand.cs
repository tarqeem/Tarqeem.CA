using System.Text.Json.Serialization;
using FluentValidation;
using Mediator;
using Tarqeem.CA.Application.Models.Common;
using Tarqeem.CA.SharedKernel.ValidationBase;
using Tarqeem.CA.SharedKernel.ValidationBase.Contracts;

namespace Tarqeem.CA.Application.Features.Order.Commands;

public record AddOrderCommand( string OrderName) : IRequest<OperationResult<bool>>,
    IValidatableModel<AddOrderCommand>
{
    [JsonIgnore]
    public int UserId { get; set; }

    public IValidator<AddOrderCommand> ValidateApplicationModel(ApplicationBaseValidationModelProvider<AddOrderCommand> validator)
    {
        validator.RuleFor(c => c.OrderName)
            .NotEmpty()
            .NotNull()
            .WithMessage("Please enter your role name");

        return validator;
    }
}