using FluentValidation;
using FluentValidation.Validators;
using ThingyThings.Server.Api.Contract.Requests.Users;

namespace ThingyThings.Server.Api.Validators;

public class RegisterUserRequestValidator : AbstractValidator<RegisterUserRequest>
{
    public RegisterUserRequestValidator()
    {
        RuleFor(_ => _.Details).NotNull();
        RuleFor(_ => _.Details).SetValidator(new RegisterUserRequestBodyValidator());
    }
}

internal class RegisterUserRequestBodyValidator : AbstractValidator<RegisterUserRequestBody>
{
    public RegisterUserRequestBodyValidator()
    {
        RuleFor(_ => _.Email).NotNull().EmailAddress();
        RuleFor(_ => _.Password).NotNull().Equal(_ => _.ConfirmPassword);
        RuleFor(_ => _.ConfirmPassword).NotNull();
    }
}
