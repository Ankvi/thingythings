using Microsoft.AspNetCore.Http.Metadata;
using Microsoft.AspNetCore.Mvc;

namespace ThingyThings.Server.Api.Contract.Responses;

public class CreatedResponse<T> : IResult, IEndpointMetadataProvider where T : class
{
    public async Task ExecuteAsync(HttpContext httpContext)
    {
        ArgumentNullException.ThrowIfNull(httpContext);

        httpContext.Response.StatusCode = StatusCodes.Status201Created;

        await httpContext.Response.WriteAsJsonAsync(this as T);
    }

    public static void PopulateMetadata(EndpointMetadataContext context)
    {
        context.EndpointMetadata.Add(new ProducesResponseTypeAttribute(typeof(ErrorResponse), StatusCodes.Status400BadRequest));
    }
}
