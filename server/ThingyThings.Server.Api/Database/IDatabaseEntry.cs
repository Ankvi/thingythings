using Npgsql;

namespace ThingyThings.Server.Api.Database;

public interface IDatabaseEntry
{
    public Task Parse(NpgsqlDataReader dataReader);
}