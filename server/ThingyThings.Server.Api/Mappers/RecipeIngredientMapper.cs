using ThingyThings.Server.Api.Contract.Dtos;
using ThingyThings.Server.Api.Contract.Requests.Recipes;
using Internal =  ThingyThings.Server.Api.Models.Recipes;

namespace ThingyThings.Server.Api.Mappers;

public interface IRecipeIngredientMapper
{
    Internal.RecipeIngredient Map(AddIngredientToRecipeRequest input);
    Internal.RecipeIngredient Map(RecipeIngredient input);
    RecipeIngredient Map(Internal.RecipeIngredient input);
}

public class RecipeIngredientMapper : IRecipeIngredientMapper
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