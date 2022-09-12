namespace ThingyThings.Server.Api.Configuration;

public class PostgresConfiguration : IConfigurationSection
{
    public string ConnectionString { get; set; }
    public string Section => "Postgres";
}