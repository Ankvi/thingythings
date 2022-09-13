using System.Threading;
using System.Threading.Tasks;
using MediatR;
using ThingyThings.Server.Api.Contract.Dtos;
using ThingyThings.Server.Api.Contract.Requests;
using ThingyThings.Server.Api.Contract.Requests.Recipes;
using ThingyThings.Server.Api.Contract.Responses;
using ThingyThings.Server.Api.Handlers.Attributes;
using ThingyThings.Server.Api.Services;

namespace ThingyThings.Server.Api.Handlers.RecipeHandlers;

public class GetRecipesHandler : IRequestHandler<GetRecipesRequest, IResult>
{
    private readonly IRecipeService _service;

    public GetRecipesHandler(IRecipeService service)
    {
        _service = service;
    }

    public async Task<IResult> Handle(GetRecipesRequest request, CancellationToken token)
    {
        var recipes = await _service.GetRecipes(token);

        return Results.Ok(recipes);
    }
}