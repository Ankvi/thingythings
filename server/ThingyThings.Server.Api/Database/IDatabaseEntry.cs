using Npgsql;

namespace ThingyThings.Server.Api.Database;

public interface IDatabaseEntry
{
    public Guid Id { get; set; }

    public Task Parse(NpgsqlDataReader dataReader);
}