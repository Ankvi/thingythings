using MediatR;
using Microsoft.AspNetCore.Mvc;
using ThingyThings.Server.Api.Contract.Responses;
using ThingyThings.Server.Api.Handlers.Attributes;

namespace ThingyThings.Server.Api.Contract.Requests.Users;

public record LoginUserRequestBody
{
    public string Email { get; set; }
    public string Password { get; set; }
}

[PostEndpoint("users/login")]
public class LoginUserRequest : HttpRequest
{
    [FromBody]
    public LoginUserRequestBody Details { get; set; }
}
