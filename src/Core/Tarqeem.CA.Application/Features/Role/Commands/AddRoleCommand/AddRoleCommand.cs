using FluentValidation;
using Mediator;
using Tarqeem.CA.Application.Models.Common;
using Tarqeem.CA.SharedKernel.ValidationBase;
using Tarqeem.CA.SharedKernel.ValidationBase.Contracts;

namespace Tarqeem.CA.Application.Features.Role.Commands.AddRoleCommand;

public record AddRoleCommand(string RoleName) : IRequest<OperationResult<bool>>,
    IValidatableModel<AddRoleCommand>
{
    public IValidator<AddRoleCommand> ValidateApplicationModel(ApplicationBaseValidationModelProvider<AddRoleCommand> validator)
    {
        validator
            .RuleFor(c => c.RoleName)
            .NotEmpty()
            .NotNull()
            .WithMessage("Please enter role name");

        return validator;
    }
};