using Npgsql;
using ThingyThings.Server.Api.Database;

namespace ThingyThings.Server.Api.Models.Users;

public record User : IDatabaseEntry
{
    public Guid Id { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string Email { get; set; }

    public async Task Parse(NpgsqlDataReader dataReader)
    {
        Id = await dataReader.GetFieldValueAsync<Guid>(0);

        if (dataReader[nameof(FirstName)] is string firstName)
        {
            FirstName = firstName;
        }

        if (dataReader[nameof(LastName)] is string lastName)
        {
            LastName = lastName;
        }

        if (dataReader[nameof(Email)] is string email)
        {
            Email = email;
        }
    }
};
