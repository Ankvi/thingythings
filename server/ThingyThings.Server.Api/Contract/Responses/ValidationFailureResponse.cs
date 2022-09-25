using FluentValidation.Results;
using ThingyThings.Server.Api.Contract.Dtos;

namespace ThingyThings.Server.Api.Contract.Responses;

public record ValidationFailureResponse(IEnumerable<ValidationFieldError> Errors)
{
    public bool Success => false;

    public static ValidationFailureResponse Create(IEnumerable<ValidationFailure> errors)
    {
        return new ValidationFailureResponse(errors.Select(_ => new ValidationFieldError(_.PropertyName, _.ErrorMessage)));
    }
};
