using ThingyThings.Server.Api.Contract.Dtos;
using Internal =  ThingyThings.Server.Api.Models.Recipes;

namespace ThingyThings.Server.Api.Mappers;

public interface IIngredientMapper
{
    Internal.Ingredient Map(Ingredient input);
    Ingredient Map(Internal.Ingredient input);
}

public class IngredientMapper :
    IIngredientMapper
{
    public Internal.Ingredient Map(Ingredient input)
    {
        return new()
        {
            Id = input.Id,
            Name = input.Name
        };
    }

    public Ingredient Map(Internal.Ingredient input)
    {
        return new Ingredient(input.Id, input.Name);
    }
}