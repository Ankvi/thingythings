using MediatR;
using Microsoft.AspNetCore.Mvc;
using ThingyThings.Server.Api.Contract.Responses;

namespace ThingyThings.Server.Api.Contract.Requests.Users;

public record LoginUserRequestBody
{
    public string Email { get; set; }
    public string Password { get; set; }
}

public class LoginUserRequest : IRequest<GeneralResponse>
{
    [FromBody]
    public LoginUserRequestBody Details { get; set; }
}
