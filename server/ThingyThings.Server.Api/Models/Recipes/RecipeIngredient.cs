using ThingyThings.Server.Api.Types;

namespace ThingyThings.Server.Api.Models.Recipes;

public record RecipeIngredient
{
    public string IngredientId { get; set; }
    public IngredientAmount Amount { get; set; }
}