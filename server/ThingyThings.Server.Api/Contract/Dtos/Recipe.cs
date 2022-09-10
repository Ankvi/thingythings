namespace ThingyThings.Server.Api.Contract.Dtos;

public record Recipe
{
    public string Id { get; init; }

    public string Description { get; init; }

    public IEnumerable<RecipeIngredient> Ingredients { get; init; }

    public IEnumerable<string> Steps { get; init; }
}