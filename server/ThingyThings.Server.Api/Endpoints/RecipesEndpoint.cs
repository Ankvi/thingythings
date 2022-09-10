using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using ThingyThings.Server.Api.Contract;

namespace ThingyThings.Server.Api.Endpoints;

public class RecipesEndpoint : EndpointBase
{

    public RecipesEndpoint(WebApplication app) : base(app, "recipes")
    {
        MapGet("/", GetRecipes);
    }

    public IResult GetRecipes()
    {
        var recipes = new List<Recipe>
        {
            new Recipe("test")
        };

        return Results.Ok(recipes);
    }
}