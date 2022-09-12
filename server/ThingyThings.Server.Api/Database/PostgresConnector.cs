using Npgsql;
using ThingyThings.Server.Api.Configuration;

namespace ThingyThings.Server.Api.Database;

public interface IPostgresConnector
{
    Task<NpgsqlConnection> Connect(CancellationToken cancellationToken);
}

public class PostgresConnector : IPostgresConnector
{
    private readonly PostgresConfiguration _config;

    public PostgresConnector(PostgresConfiguration config)
    {
        _config = config;
    }
    
    public async Task<NpgsqlConnection> Connect(CancellationToken cancellationToken)
    {
        var connection = new NpgsqlConnection(_config.ConnectionString);
        await connection.OpenAsync(cancellationToken);
        return connection;
    }
}