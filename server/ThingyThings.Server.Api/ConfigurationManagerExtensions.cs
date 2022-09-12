using IConfigurationSection = ThingyThings.Server.Api.Configuration.IConfigurationSection;

namespace ThingyThings.Server.Api;

public static class ConfigurationManagerExtensions
{
    public static T? GetSection<T>(this ConfigurationManager configuration) where T : IConfigurationSection, new()
    {
        var config = new T();
        var section = configuration.GetSection(config.Section);
        return section.Get<T>();
    }
}