using FluentValidation.Results;

namespace ThingyThings.Server.Api.Contract.Responses;

public record ValidationFailureResponse(IEnumerable<string> Errors)
{
    public bool Success => false;

    public static ValidationFailureResponse Create(IEnumerable<ValidationFailure> errors)
    {
        return new ValidationFailureResponse(errors.Select(_ => _.ErrorMessage));
    }
};
