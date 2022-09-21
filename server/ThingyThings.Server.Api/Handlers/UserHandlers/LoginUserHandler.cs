using MediatR;
using ThingyThings.Server.Api.Contract.Requests.Users;
using ThingyThings.Server.Api.Contract.Responses;
using ThingyThings.Server.Api.Services;

namespace ThingyThings.Server.Api.Handlers.UserHandlers;

public class LoginUserHandler : IRequestHandler<LoginUserRequest, GeneralResponse>
{
    private readonly IUserService _service;

    public LoginUserHandler(IUserService service)
    {
        _service = service;
    }

    public async Task<GeneralResponse> Handle(LoginUserRequest request, CancellationToken cancellationToken)
    {
        var user = await _service.LoginUser(request.Details.Email, request.Details.Password, cancellationToken);

        return user is null
            ? new ErrorResponse("Invalid email or password")
            : new GeneralResponse(true, "Logged in");
    }
}
