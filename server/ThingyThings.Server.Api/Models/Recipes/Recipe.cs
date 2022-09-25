using Npgsql;
using ThingyThings.Server.Api.Database;

namespace ThingyThings.Server.Api.Models.Recipes;

public record Recipe : IDatabaseEntry
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public IEnumerable<RecipeIngredient> Ingredients { get; set; }
    public IEnumerable<string> Steps { get; set; }

    // public async Task Parse(NpgsqlDataReader dataReader)
    // {
    //     Id = await dataReader.GetFieldValueAsync<Guid>(0);
    //     Name = await dataReader.GetFieldValueAsync<string>(1);
    //     Description = await dataReader.GetFieldValueAsync<string>(2);
    //     Steps = await dataReader.GetFieldValueAsync<string[]>(3);
    // }
}
