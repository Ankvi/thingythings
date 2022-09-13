using Microsoft.AspNetCore.Mvc;

namespace ThingyThings.Server.Api.Contract.Requests;

public class HttpRequestWithBody<T> : HttpRequest where T : class
{
    [FromBody]
    public T Body { get; set; }
}