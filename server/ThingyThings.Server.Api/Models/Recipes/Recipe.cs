using ThingyThings.Server.Api.Database;

namespace ThingyThings.Server.Api.Models.Recipes;

public record Recipe : IDatabaseEntry
{
    public string Id { get; set; }
    
    public string GetTableName()
    {
        return nameof(Recipe);
    }

    public string Description { get; set; }
    public IEnumerable<RecipeIngredient> Ingredients { get; set; }
    public IEnumerable<string> Steps { get; set; }
}