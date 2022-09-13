using ThingyThings.Server.Api.Handlers.Attributes;

namespace ThingyThings.Server.Api.Contract.Requests.Recipes;

[GetEndpoint("recipes")]
public record GetRecipesRequest : IHttpRequest
{

}