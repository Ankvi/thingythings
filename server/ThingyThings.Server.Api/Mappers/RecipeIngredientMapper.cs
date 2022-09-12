using ThingyThings.Server.Api.Contract.Dtos;
using Internal =  ThingyThings.Server.Api.Models.Recipes;

namespace ThingyThings.Server.Api.Mappers;

public class RecipeIngredientMapper :
    IMapper<RecipeIngredient, Internal.RecipeIngredient>,
    IMapper<Internal.RecipeIngredient, RecipeIngredient>
{
    private readonly IIngredientMapper _ingredientMapper;

    public RecipeIngredientMapper(IIngredientMapper ingredientMapper)
    {
        _ingredientMapper = ingredientMapper;
    }

    public Internal.RecipeIngredient Map(RecipeIngredient input)
    {
        return new()
        {
            IngredientId = input.IngredientId,
            Amount = input.Amount
        };
    }

    public RecipeIngredient Map(Internal.RecipeIngredient input)
    {
        return new()
        {
            IngredientId = input.IngredientId,
            Amount = input.Amount
        };
    }
}