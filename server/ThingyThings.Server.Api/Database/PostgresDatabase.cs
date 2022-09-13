using Npgsql;

namespace ThingyThings.Server.Api.Database;

public interface IPostgresDatabase
{
    Task<IEnumerable<T>> Get<T>(string query, IEnumerable<NpgsqlParameter>? parameters, CancellationToken token)
        where T : IDatabaseEntry, new();
    Task<IEnumerable<T>> Get<T>(string query, CancellationToken token)
        where T : IDatabaseEntry, new();
    Task<T> GetSingle<T>(string query, IEnumerable<NpgsqlParameter>? parameters, CancellationToken token)
        where T : IDatabaseEntry, new();
    Task<T> GetSingle<T>(string query, CancellationToken token)
        where T : IDatabaseEntry, new();
}

public class PostgresDatabase : IPostgresDatabase
{
    private readonly IPostgresConnector _connector;

    public PostgresDatabase(IPostgresConnector connector)
    {
        _connector = connector;
    }

    public async Task<IEnumerable<T>> Get<T>(string query, IEnumerable<NpgsqlParameter>? parameters, CancellationToken token)
        where T : IDatabaseEntry, new()
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
            var row = new T();
            await row.Parse(reader);
            result.Add(row);
        }

        return result;
    }

    public async Task<IEnumerable<T>> Get<T>(string query, CancellationToken token)
        where T : IDatabaseEntry, new()
    {
        return await Get<T>(query, null, token);
    }

    public async Task<T> GetSingle<T>(string query, IEnumerable<NpgsqlParameter>? parameters, CancellationToken token) where T : IDatabaseEntry, new()
    {
        var result = await Get<T>(query, parameters, token);

        if (!result.Any())
        {
            throw new NotFoundException();
        }

        return result.First();
    }

    public async Task<T> GetSingle<T>(string query, CancellationToken token) where T : IDatabaseEntry, new()
    {
        return await GetSingle<T>(query, null, token);
    }

    // public async Task<T> Insert<T>(string query, IEnumerable<NpgsqlParameter> parameters, CancellationToken token)
    // {
    //     var connection = await _connector.Connect(token);
    //
    //     await using var command = new NpgsqlCommand(query, connection)
    //     {
    //         Parameters = { parameters }
    //     };
    //
    //     await using var reader = await command.ExecuteReaderAsync(token);
    // }
}