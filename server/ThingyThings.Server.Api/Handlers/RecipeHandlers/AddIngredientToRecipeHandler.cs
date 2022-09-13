using MediatR;
using ThingyThings.Server.Api.Contract.Dtos;
using ThingyThings.Server.Api.Contract.Requests.Recipes;
using ThingyThings.Server.Api.Mappers;
using ThingyThings.Server.Api.Services;
using RecipeIngredient = ThingyThings.Server.Api.Models.Recipes.RecipeIngredient;

namespace ThingyThings.Server.Api.Handlers.RecipeHandlers;

public class AddIngredientToRecipeHandler : IRequestHandler<AddIngredientToRecipeRequest, IResult>
{
    private readonly IRecipeService _service;
    private readonly IMapper<AddIngredientToRecipeRequest, RecipeIngredient> _requestMapper;

    public AddIngredientToRecipeHandler(
        IRecipeService service,
        IMapper<AddIngredientToRecipeRequest, RecipeIngredient> requestMapper)
    {
        _service = service;
        _requestMapper = requestMapper;
    }
    
    public async Task<IResult> Handle(AddIngredientToRecipeRequest request, CancellationToken cancellationToken)
    {
        var ingredient = _requestMapper.Map(request);
        await _service.AddIngredientToRecipe(request.Id, ingredient, cancellationToken);
        return Results.Ok();
    }
}