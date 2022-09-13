using ThingyThings.Server.Api.Contract.Dtos;
using ThingyThings.Server.Api.Handlers.Attributes;

namespace ThingyThings.Server.Api.Contract.Requests.Recipes;

[PostEndpoint("recipes")]
public class AddRecipeRequest : HttpRequestWithBody<Recipe>
{

}