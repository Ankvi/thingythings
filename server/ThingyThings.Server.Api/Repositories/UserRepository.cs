using Npgsql;
using ThingyThings.Server.Api.Database;
using ThingyThings.Server.Api.Models.Users;

namespace ThingyThings.Server.Api.Repositories;

public interface IUserRepository
{
    Task<User?> LoginUser(string email, string password, CancellationToken token);
    Task<User> RegisterUser(NewUser user, CancellationToken token);
}

public class UserRepository : IUserRepository
{
    private readonly IPostgresDatabase _database;

    public UserRepository(IPostgresDatabase database)
    {
        _database = database;
    }

    public async Task<User?> LoginUser(string email, string password, CancellationToken token)
    {
        return await _database.GetSingle<User>(@"
            SELECT id, firstname, lastname, email
            FROM users
            WHERE email = @email
            AND password = crypt(@password, password)
        ", new[]
        {
            new NpgsqlParameter<string>("email", email),
            new NpgsqlParameter<string>("password", password)
        }, token);
    }

    public async Task<User> RegisterUser(NewUser user, CancellationToken token)
    {
        return await _database.GetSingle<User>(@"
            INSERT INTO users(firstname, lastname, email, password)
            VALUES($1, $2, $3, crypt($4, gen_salt('bf')))
            RETURNING *
        ", new[]
        {
            new NpgsqlParameter<string>{ TypedValue = user.FirstName },
            new NpgsqlParameter<string>{ TypedValue = user.LastName },
            new NpgsqlParameter<string>{ TypedValue = user.Email },
            new NpgsqlParameter<string>{ TypedValue = user.Password },
        }, token);
    }
}
