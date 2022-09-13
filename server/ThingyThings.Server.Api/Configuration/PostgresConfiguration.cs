namespace ThingyThings.Server.Api.Configuration;

public class PostgresConfiguration : IConfigurationSection
{
    public string ConnectionString => $"Host={Host}:{Port};Username={Username};Password={Password};Database={Database}";
    public string Host { get; set; } = "localhost";
    public string Port { get; set; } = "5432";
    public string Username { get; set; } = "postgres";
    public string Password { get; set; } = "";
    public string Database { get; set; } = "";
    public string Section => "Postgres";
}

// Host=localhost:5432;User=postgres;Password=sup3rs3cur3;Database=thingythings