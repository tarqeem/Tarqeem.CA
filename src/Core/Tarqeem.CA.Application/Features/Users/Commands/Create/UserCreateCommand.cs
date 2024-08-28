using System.Text.RegularExpressions;
using Tarqeem.CA.Domain.Entities.User;
using FluentValidation;
using Mediator;
using Tarqeem.CA.Application.Models.Common;
using Tarqeem.CA.Application.Profiles;
using Tarqeem.CA.SharedKernel.ValidationBase;
using Tarqeem.CA.SharedKernel.ValidationBase.Contracts;

namespace Tarqeem.CA.Application.Features.Users.Commands.Create;

public record UserCreateCommand(string UserName, string Name, string FamilyName, string Password)
    : IRequest<OperationResult<UserCreateCommandResult>>
        , IValidatableModel<UserCreateCommand>
        , ICreateMapper<User>
{
    public IValidator<UserCreateCommand> ValidateApplicationModel(
        ApplicationBaseValidationModelProvider<UserCreateCommand> validator)
    {
        validator
            .RuleFor(c => c.Name)
            .NotEmpty()
            .NotNull()
            .WithMessage("User must have first name");

        validator.RuleFor(c => c.UserName)
            .NotEmpty()
            .NotNull()
            .WithMessage("Please enter your username");

        validator
            .RuleFor(c => c.FamilyName)
            .NotEmpty()
            .NotNull()
            .WithMessage("User must have last name");


        validator.RuleFor(c => c.Password).NotEmpty()
            .NotNull().WithMessage("Password is required.").MinimumLength(4)
            .WithMessage("Password must have at least 4 characters");

        return validator;
    }
}