using Microsoft.AspNetCore.Mvc;

namespace ThingyThings.Server.Api.Contract.Requests;

public class HttpRequest : IHttpRequest
{
    [FromHeader]
    public string? TestAttribute { get; set; }
}