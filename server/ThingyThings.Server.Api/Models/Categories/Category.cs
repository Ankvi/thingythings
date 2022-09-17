using System.Text.Json.Serialization;
using Npgsql;
using ThingyThings.Server.Api.Database;
using ThingyThings.Server.Api.Types;

namespace ThingyThings.Server.Api.Models.Categories;

public record Category : IDatabaseEntry
{
    public Guid Id { get; set; }
    
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public CategoryType Type { get; set; }
    
    public string Name { get; set; }
    
    public async Task Parse(NpgsqlDataReader dataReader)
    {
        Id = await dataReader.GetFieldValueAsync<Guid>(0);
        Type = await dataReader.GetFieldValueAsync<CategoryType>(1);
        Name = await dataReader.GetFieldValueAsync<string>(2);
    }
};