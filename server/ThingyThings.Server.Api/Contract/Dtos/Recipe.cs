namespace ThingyThings.Server.Api.Contract.Dtos;

public class Recipe
{
    public string Name { get; set; }
    public string Description { get; set; }

    public IEnumerable<RecipeIngredient> Ingredients { get; set; }

    public IEnumerable<string> Steps { get; set; }
}