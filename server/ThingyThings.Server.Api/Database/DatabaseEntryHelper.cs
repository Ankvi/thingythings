using System.Reflection;
using Npgsql;

namespace ThingyThings.Server.Api.Database;

public static class DatabaseEntryHelper
{
    public static void SetFieldValues<T>(NpgsqlDataReader reader, T input) where T : IDatabaseEntry
    {
        var properties = typeof(T).GetProperties(BindingFlags.Instance | BindingFlags.Public);
        foreach (var property in properties)
        {
            var value = reader[property.Name];
            if (value.GetType() == property.PropertyType)
            {
                property.SetValue(input, value);
            }
        }
    }
}
