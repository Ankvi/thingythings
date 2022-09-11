using Microsoft.AspNetCore.Mvc;

namespace ThingyThings.Server.Api.Contract.Dtos;

public class Recipe
{
    [FromBody]
    public string Description { get; set; }

    [FromBody]
    public IEnumerable<RecipeIngredient> Ingredients { get; set; }

    [FromBody]
    public IEnumerable<string> Steps { get; set; }
}