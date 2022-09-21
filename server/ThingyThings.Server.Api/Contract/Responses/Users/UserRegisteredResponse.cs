using Microsoft.AspNetCore.Http.Metadata;
using Microsoft.AspNetCore.Mvc;

namespace ThingyThings.Server.Api.Contract.Responses.Users;

public class UserRegisteredResponse : IResult, IEndpointMetadataProvider
{
    public bool Success { get; set; }

    public static void PopulateMetadata(EndpointMetadataContext context)
    {
        context.EndpointMetadata.Add(new ProducesResponseTypeAttribute(typeof(UserRegisteredResponse), StatusCodes.Status201Created));
    }

    public async Task ExecuteAsync(HttpContext httpContext)
    {
        ArgumentNullException.ThrowIfNull(httpContext);

        httpContext.Response.StatusCode = StatusCodes.Status201Created;

        await httpContext.Response.WriteAsJsonAsync(this);
    }
}
