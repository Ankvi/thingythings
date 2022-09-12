using ThingyThings.Server.Api.Types;

namespace ThingyThings.Server.Api.Contract.Dtos;

public record RecipeIngredient
{
    public string IngredientId { get; set; }
    public IngredientAmount Amount { get; set; }
}