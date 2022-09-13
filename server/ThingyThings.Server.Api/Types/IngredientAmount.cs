using System.Text.Json.Serialization;


namespace ThingyThings.Server.Api.Types;

public record IngredientAmount
{
    public decimal Amount { get; set; }
    
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public Measurement Measurement { get; set; }
}