using FluentValidation;
using FluentValidation.Results;
using MediatR;
using ThingyThings.Server.Api.Contract.Requests.Users;
using ThingyThings.Server.Api.Contract.Responses;
using ThingyThings.Server.Api.Contract.Responses.Users;
using ThingyThings.Server.Api.Mappers;
using ThingyThings.Server.Api.Models.Users;
using ThingyThings.Server.Api.Services;

namespace ThingyThings.Server.Api.Handlers.UserHandlers;

public class RegisterUserHandler : IRequestHandler<RegisterUserRequest, IResult>
{
    private readonly IUserService _service;
    private readonly IValidator<RegisterUserRequest> _validator;
    private readonly IMapper<RegisterUserRequest, NewUser> _requestMapper;
    private readonly IMapper<User, UserRegisteredResponse> _responseMapper;

    public RegisterUserHandler(
        IUserService service,
        IValidator<RegisterUserRequest> validator,
        IMapper<RegisterUserRequest, NewUser> requestMapper,
        IMapper<User, UserRegisteredResponse> responseMapper)
    {
        _service = service;
        _validator = validator;
        _requestMapper = requestMapper;
        _responseMapper = responseMapper;
    }

    public async Task<IResult> Handle(RegisterUserRequest userRequest, CancellationToken cancellationToken)
    {
        var result = _validator.Validate(userRequest);
        if (!result.IsValid)
        {
            return Results.BadRequest(ValidationFailureResponse.Create(result.Errors));
        }

        var newUser = _requestMapper.Map(userRequest);
        var registeredUser = await _service.RegisterUser(newUser, cancellationToken);

        return new UserRegisteredResponse
        {
            Success = true
        };
    }
}
