using MediatR;
using Microsoft.AspNetCore.Mvc;
using ThingyThings.Server.Api.Contract.Responses.Users;
using ThingyThings.Server.Api.Handlers.Attributes;

namespace ThingyThings.Server.Api.Contract.Requests.Users;

public record RegisterUserRequestBody
{
    public string Email { get; set; }
    public string Password { get; set; }
}

[PostEndpoint("users/register")]
public class RegisterUserRequest : IRequest<UserRegisteredResponse>
{
    [FromBody]
    public RegisterUserRequestBody Details { get; set; }
}
