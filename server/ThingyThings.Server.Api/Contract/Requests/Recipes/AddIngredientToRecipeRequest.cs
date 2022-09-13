using Microsoft.AspNetCore.Mvc;
using ThingyThings.Server.Api.Contract.Dtos;
using ThingyThings.Server.Api.Handlers.Attributes;

namespace ThingyThings.Server.Api.Contract.Requests.Recipes;

[PostEndpoint("recipes/{id}/ingredient")]
public class AddIngredientToRecipeRequest : HttpRequestWithBody<RecipeIngredient>
{
    [FromRoute(Name = "id")]
    public Guid Id { get; set; }
}