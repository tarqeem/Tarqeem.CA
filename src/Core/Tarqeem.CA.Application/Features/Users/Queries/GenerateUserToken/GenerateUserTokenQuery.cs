using FluentValidation;
using Mediator;
using Tarqeem.CA.Application.Models.Common;
using Tarqeem.CA.Application.Models.Jwt;
using Tarqeem.CA.SharedKernel.ValidationBase;
using Tarqeem.CA.SharedKernel.ValidationBase.Contracts;

namespace Tarqeem.CA.Application.Features.Users.Queries.GenerateUserToken;

public record GenerateUserTokenQuery(string UserKey, string Code) : IRequest<OperationResult<AccessToken>>,
    IValidatableModel<GenerateUserTokenQuery>
{
    public IValidator<GenerateUserTokenQuery> ValidateApplicationModel(ApplicationBaseValidationModelProvider<GenerateUserTokenQuery> validator)
    {
        validator.RuleFor(c => c.Code)
            .NotEmpty()
            .NotNull()
            .Length(6)
            .WithMessage("User code is not valid");

        validator.RuleFor(c => c.UserKey)
            .NotEmpty()
            .NotNull()
            .WithMessage("Invalid user key");

        return validator;
    }
};