

using Npgsql;
using ThingyThings.Server.Api.Database;
using ThingyThings.Server.Api.Models.Recipes;
using ThingyThings.Server.Api.Types;

namespace ThingyThings.Server.Api.Repositories;

public interface IRecipeRepository
{
    Task<Recipe> AddRecipe(Recipe recipe, CancellationToken token);
    Task<IEnumerable<Recipe>> GetRecipes(CancellationToken token);
    Task AddIngredientToRecipe(string id, RecipeIngredient ingredient, CancellationToken token);
}

public class RecipeRepository : IRecipeRepository
{
    private readonly IPostgresDatabase _database;

    public RecipeRepository(IPostgresDatabase database)
    {
        _database = database;
    }
    
    public Task<Recipe> AddRecipe(Recipe recipe, CancellationToken token)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<Recipe>> GetRecipes(CancellationToken token)
    {
        var result = await _database.Get<Recipe>($@"
            SELECT *
            FROM recipe.recipes
        ", token);

        return result;
    }

    public Task AddIngredientToRecipe(string id, RecipeIngredient ingredient, CancellationToken token)
    {
        throw new NotImplementedException();
    }
}