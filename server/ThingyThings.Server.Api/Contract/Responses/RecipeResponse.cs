using ThingyThings.Server.Api.Contract.Dtos;

namespace ThingyThings.Server.Api.Contract.Responses;

public class RecipeResponse : Recipe
{
    public string Id { get; set; }
}