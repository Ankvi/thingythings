namespace ThingyThings.Server.Api.Contract.Dtos;

public record RecipeIngredient
{
    public Ingredient Ingredient { get; set; }
    public  decimal Amount { get; set; }
    public string Measurement { get; set; }
}