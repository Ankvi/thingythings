using ThingyThings.Server.Api.Contract.Dtos;
using ThingyThings.Server.Api.Handlers.Attributes;

namespace ThingyThings.Server.Api.Contract.Requests.Recipes;

[PostEndpoint("recipes/{id}")]
public class AddIngredientToRecipe : IHttpRequest
{
    public string Id { get; set; }
    public RecipeIngredient Ingredient { get; set; }
}