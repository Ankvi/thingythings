using MediatR;
using ThingyThings.Server.Api.Contract.Dtos;
using ThingyThings.Server.Api.Contract.Requests.Recipes;
using ThingyThings.Server.Api.Mappers;
using ThingyThings.Server.Api.Services;
using Internal = ThingyThings.Server.Api.Models.Recipes;

namespace ThingyThings.Server.Api.Handlers.RecipeHandlers;

public class AddIngredientToRecipeHandler : IRequestHandler<AddIngredientToRecipe, IResult>
{
    private readonly IRecipeService _service;
    private readonly IMapper<RecipeIngredient, Internal.RecipeIngredient> _ingredientMapper;

    public AddIngredientToRecipeHandler(IRecipeService service)
    {
        _service = service;
    }
    
    public async Task<IResult> Handle(AddIngredientToRecipe request, CancellationToken cancellationToken)
    {
        var ingredient = _ingredientMapper.Map(request.Ingredient);
        await _service.AddIngredientToRecipe(request.Id, ingredient);
        return Results.Ok();
    }
}