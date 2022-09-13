using Npgsql;
using ThingyThings.Server.Api.Database;

namespace ThingyThings.Server.Api.Models.Recipes;

public record Ingredient : IDatabaseEntry
{
    public Guid Id { get; set; }

    public string Name { get; set; }

    public async Task Parse(NpgsqlDataReader dataReader)
    {
        Id = await dataReader.GetFieldValueAsync<Guid>(0);
        Name = await dataReader.GetFieldValueAsync<string>(1);
    }
}
