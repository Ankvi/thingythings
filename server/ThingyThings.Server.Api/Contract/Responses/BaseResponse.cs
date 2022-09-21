using Microsoft.AspNetCore.Http.Metadata;
using Microsoft.AspNetCore.Mvc;

namespace ThingyThings.Server.Api.Contract.Responses;

public abstract class BaseResponse<T> : IResult//, IEndpointMetadataProvider
    where T : class
{
    private readonly int _statusCode;

    protected BaseResponse(int statusCode)
    {
        _statusCode = statusCode;
    }

    public Task ExecuteAsync(HttpContext httpContext)
    {
        ArgumentNullException.ThrowIfNull(httpContext);

        httpContext.Response.StatusCode = _statusCode;

        return Task.CompletedTask;
    }

    // public static void PopulateMetadata(EndpointMetadataContext context)
    // {
    //     context.EndpointMetadata.Add(new ProducesResponseTypeAttribute(typeof(T), StatusCodes.Status201Created));
    // }
}
