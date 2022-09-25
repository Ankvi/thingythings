using Npgsql;
using ThingyThings.Server.Api.Database;
using ThingyThings.Server.Api.Models.Recipes;

namespace ThingyThings.Server.Api.Repositories;

public interface IIngredientRepository
{
    Task<Ingredient> AddIngredient(Ingredient ingredient, CancellationToken token);
    Task<IEnumerable<Ingredient>> GetIngredients(CancellationToken token);
    Task<Ingredient> GetIngredient(string id, CancellationToken token);
}

public class IngredientRepository : IIngredientRepository
{
    private readonly IPostgresDatabase _database;

    public IngredientRepository(IPostgresDatabase database)
    {
        _database = database;
    }

    public async Task<Ingredient> AddIngredient(Ingredient ingredient, CancellationToken token)
    {
        var result = await _database.GetSingle<Ingredient>(@"
            INSERT INTO recipes.ingredient(name)
            VALUES(@name)
            RETURNING *
        ", new []
        {
            new NpgsqlParameter("name", ingredient.Name)
        }, token);

        return result;
    }

    public async Task<IEnumerable<Ingredient>> GetIngredients(CancellationToken token)
    {
        return await _database.Get<Ingredient>(@"
            SELECT *
            FROM recipes.ingredient
        ", token);
    }

    public async Task<Ingredient> GetIngredient(string id, CancellationToken token)
    {
        return await _database.GetSingle<Ingredient>(@"
            SELECT *
            FROM recipes.ingredient
            WHERE id = (@id)
        ", new []
        {
            new NpgsqlParameter<string>("id", id)
        }, token);
    }
}
