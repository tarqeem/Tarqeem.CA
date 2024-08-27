﻿using FluentValidation;
using Mediator;
using Tarqeem.CA.Application.Models.Common;
using Tarqeem.CA.SharedKernel.ValidationBase;
using Tarqeem.CA.SharedKernel.ValidationBase.Contracts;

namespace Tarqeem.CA.Application.Features.Admin.Commands.AddAdminCommand;

public record AddAdminCommand
    (string UserName, string Email, string Password, int RoleId) : IRequest<OperationResult<bool>>,
        IValidatableModel<AddAdminCommand>
{
    public IValidator<AddAdminCommand> ValidateApplicationModel(ApplicationBaseValidationModelProvider<AddAdminCommand> validator)
    {
        validator.RuleFor(c => c.Email)
            .EmailAddress()
            .WithMessage("Please enter an valid email");

        validator.RuleFor(c => c.UserName)
            .NotEmpty()
            .NotNull()
            .WithMessage("Please specify a valid username");

        validator
            .RuleFor(c => c.RoleId)
            .GreaterThan(0)
            .WithMessage("Please select a valid role");

        return validator;
    }
};