

using Npgsql;
using ThingyThings.Server.Api.Database;
using ThingyThings.Server.Api.Models.Recipes;
using ThingyThings.Server.Api.Types;

namespace ThingyThings.Server.Api.Repositories;

public interface IRecipeRepository
{
    Task<Recipe> AddRecipe(Recipe recipe);
    Task<IEnumerable<Recipe>> GetRecipes(CancellationToken token);
    Task AddIngredientToRecipe(string id, RecipeIngredient ingredient);
}

public class RecipeRepository : IRecipeRepository
{
    private readonly IPostgresDatabase<Recipe> _database;
    public Task<Recipe> AddRecipe(Recipe recipe)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<Recipe>> GetRecipes(CancellationToken token)
    {
        var result = await _database.Get($@"
            SELECT *
            FROM {_database.GetTableName()}
        ", token);

        return result;
    }

    public Task AddIngredientToRecipe(string id, RecipeIngredient ingredient)
    {
        throw new NotImplementedException();
    }
}