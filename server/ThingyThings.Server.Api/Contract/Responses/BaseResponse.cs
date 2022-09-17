using Microsoft.AspNetCore.Http.Metadata;
using Microsoft.AspNetCore.Mvc;

namespace ThingyThings.Server.Api.Contract.Responses;

public class BaseResponse<T> : IEndpointMetadataProvider
    where T : class
{
    public static void PopulateMetadata(EndpointMetadataContext context)
    {
        context.EndpointMetadata.Add(new ProducesResponseTypeAttribute(typeof(T), StatusCodes.Status200OK));
    }
}