using MediatR;
using ThingyThings.Server.Api.Contract.Requests.Users;
using ThingyThings.Server.Api.Contract.Responses.Users;
using ThingyThings.Server.Api.Services;

namespace ThingyThings.Server.Api.Handlers.UserHandlers;

public class RegisterUserHandler : IRequestHandler<RegisterUserRequest, UserRegisteredResponse>
{
    private readonly IUserService _service;

    public RegisterUserHandler(IUserService service)
    {
        _service = service;
    }

    public async Task<UserRegisteredResponse> Handle(RegisterUserRequest userRequest, CancellationToken cancellationToken)
    {
        var registeredUser = await _service.RegisterUser(null, cancellationToken);

        return new UserRegisteredResponse
        {
            Success = true
        };
    }
}
