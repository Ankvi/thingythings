using Npgsql;

namespace ThingyThings.Server.Api.Database;

public interface IPostgresDatabase<T> where T : IDatabaseEntry
{
    Task<IEnumerable<T>> Get(string query, IEnumerable<NpgsqlParameter>? parameters, CancellationToken token);
    Task<IEnumerable<T>> Get(string query, CancellationToken token);
    string GetTableName();
}

public class PostgresDatabase<T> : IPostgresDatabase<T> where T : IDatabaseEntry
{
    private readonly IPostgresConnector _connector;
    private readonly string _tableName = nameof(T);

    public PostgresDatabase(IPostgresConnector connector)
    {
        _connector = connector;
    }

    public async Task<IEnumerable<T>> Get(string query, IEnumerable<NpgsqlParameter>? parameters, CancellationToken token)
    {
        var connection = await _connector.Connect(token);

        await using var command = new NpgsqlCommand(query, connection);
        if (parameters is not null)
        {
            command.Parameters.AddRange(parameters.ToArray());
        }

        await using var reader = await command.ExecuteReaderAsync(token);

        var result = new List<T>();
        while (await reader.ReadAsync(token))
        {
            var row = await reader.GetFieldValueAsync<T>(0, token);
            result.Add(row);
        }

        return result;
    }

    public async Task<IEnumerable<T>> Get(string query, CancellationToken token)
    {
        return await Get(query, null, token);
    }

    public string GetTableName()
    {
        return nameof(T);
    }
}