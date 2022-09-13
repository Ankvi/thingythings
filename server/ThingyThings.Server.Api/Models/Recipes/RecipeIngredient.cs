using Npgsql;
using ThingyThings.Server.Api.Database;
using ThingyThings.Server.Api.Types;

namespace ThingyThings.Server.Api.Models.Recipes;

public record RecipeIngredient : IngredientAmount, IDatabaseEntry
{
    public string Name { get; set; }
    
    public async Task Parse(NpgsqlDataReader dataReader)
    {
        Name = await dataReader.GetFieldValueAsync<string>(0);
        Amount = await dataReader.GetFieldValueAsync<decimal>(1);
        Measurement = await dataReader.GetFieldValueAsync<Measurement>(2);
    }
}