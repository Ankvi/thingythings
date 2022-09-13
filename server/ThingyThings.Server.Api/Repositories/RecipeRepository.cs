

using Npgsql;
using ThingyThings.Server.Api.Database;
using ThingyThings.Server.Api.Models.Recipes;
using ThingyThings.Server.Api.Types;

namespace ThingyThings.Server.Api.Repositories;

public interface IRecipeRepository
{
    Task<Recipe> AddRecipe(Recipe recipe, CancellationToken token);
    Task<IEnumerable<Recipe>> GetRecipes(CancellationToken token);
    Task AddIngredientToRecipe(Guid id, RecipeIngredient ingredient, CancellationToken token);
}

public class RecipeRepository : IRecipeRepository
{
    private readonly IPostgresDatabase _database;

    public RecipeRepository(IPostgresDatabase database)
    {
        _database = database;
    }

    public async Task<Recipe> AddRecipe(Recipe recipe, CancellationToken token)
    {
        var result = await _database.GetSingle<Recipe>(@"
            INSERT INTO recipe.recipes(name, description, steps)
            VALUES(@name, @description, @steps)
            RETURNING *
        ", new List<NpgsqlParameter>
        {
            new NpgsqlParameter<string>("name", recipe.Name),
            new NpgsqlParameter<string>("description", recipe.Description),
            new NpgsqlParameter<string[]>("steps", recipe.Steps.ToArray())
        }, token);

        await Parallel.ForEachAsync(recipe.Ingredients, token, async (ingredient, ingredientToken) =>
        {
            await AddIngredientToRecipe(result.Id, ingredient, ingredientToken);
        });

        return result;
    }

    public async Task<IEnumerable<Recipe>> GetRecipes(CancellationToken token)
    {
        var result = await _database.Get<Recipe>($@"
            SELECT *
            FROM recipe.recipes
        ", token);

        await Parallel.ForEachAsync(result, token, async (recipe, _) =>
        {
            var ingredients = await _database.Get<RecipeIngredient>(@"
                SELECT i.name, ri.amount, ri.measurement
                FROM recipe.ingredients ri
                LEFT JOIN ingredient.ingredients i
                ON ri.ingredientId = i.id
                WHERE ri.recipeId = @id
            ", new[]
            {
                new NpgsqlParameter<Guid>("id", recipe.Id)
            }, _);
            recipe.Ingredients = ingredients;
        });

        return result;
    }

    public async Task AddIngredientToRecipe(Guid id, RecipeIngredient ingredient, CancellationToken token)
    {
        await _database.Execute(@"
            INSERT INTO recipe.ingredients(recipeId, ingredientId, amount, measurement)
            VALUES($1, (
                SELECT id FROM ingredient.ingredients
                WHERE name = $2
            ), $3, $4)
        ", new List<NpgsqlParameter>
        {
            new NpgsqlParameter<Guid>{ TypedValue = id },
            new NpgsqlParameter<string>{ TypedValue = ingredient.Name },
            new NpgsqlParameter<decimal>{ TypedValue = ingredient.Amount },
            new NpgsqlParameter<Measurement>{ TypedValue = ingredient.Measurement }
        }
        , token);
    }
}