using ThingyThings.Server.Api.Types;

namespace ThingyThings.Server.Api.Contract.Dtos;

public record RecipeIngredient : IngredientAmount
{
    public string Name { get; set; }
}