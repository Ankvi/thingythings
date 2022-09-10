using MediatR;
using ThingyThings.Server.Api.Contract.Responses;
using ThingyThings.Server.Api.Handlers.Attributes;

namespace ThingyThings.Server.Api.Contract.Requests;

[GetEndpoint("")]
public record RecipesRequest : IRequest<IEnumerable<RecipeResponse>>
{
    
}