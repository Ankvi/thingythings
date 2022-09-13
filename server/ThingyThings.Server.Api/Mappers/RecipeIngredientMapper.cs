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
            Name = input.Name,
            Amount = input.Amount,
            Measurement = input.Measurement
        };
    }

    public RecipeIngredient Map(Internal.RecipeIngredient input)
    {
        return new()
        {
            Name = input.Name,
            Amount = input.Amount,
            Measurement = input.Measurement
        };
    }

    public Internal.RecipeIngredient Map(AddIngredientToRecipeRequest input)
    {
        return new Internal.RecipeIngredient
        {
            Name = input.Body.Name,
            Amount = input.Body.Amount,
            Measurement = input.Body.Measurement
        };
    }
}