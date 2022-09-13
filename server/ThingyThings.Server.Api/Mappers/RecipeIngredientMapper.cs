using ThingyThings.Server.Api.Contract.Dtos;
using ThingyThings.Server.Api.Contract.Requests.Recipes;
using Internal =  ThingyThings.Server.Api.Models.Recipes;

namespace ThingyThings.Server.Api.Mappers;

public class RecipeIngredientMapper :
    IMapper<AddIngredientToRecipeRequest, Internal.RecipeIngredient>,
    IMapper<RecipeIngredient, Internal.RecipeIngredient>,
    IMapper<Internal.RecipeIngredient, RecipeIngredient>
{
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

    public Internal.RecipeIngredient Map(AddIngredientToRecipeRequest input)
    {
        return new Internal.RecipeIngredient
        {
            IngredientId = input.Ingredient.IngredientId,
            Amount = input.Ingredient.Amount
        };
    }
}