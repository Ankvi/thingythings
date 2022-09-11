using System.Threading;
using System.Threading.Tasks;
using MediatR;
using ThingyThings.Server.Api.Contract.Dtos;
using ThingyThings.Server.Api.Contract.Requests;
using ThingyThings.Server.Api.Contract.Responses;
using ThingyThings.Server.Api.Handlers.Attributes;
using ThingyThings.Server.Api.Services;

namespace ThingyThings.Server.Api.Handlers.RecipeHandlers;

public class GetRecipesHandler : IRequestHandler<GetRecipesRequest, IResult>
{
    private readonly IRecipeService _service;

    public GetRecipesHandler(IRecipeService service)
    {
        _service = service;
    }

    public async Task<IResult> Handle(GetRecipesRequest request, CancellationToken cancellationToken)
    {
        var recipes = new List<RecipeResponse>
        {
            new ()
            {
                Id = "1",
                Description = "Pho",
                Ingredients = new []
                {
                    new RecipeIngredient
                    {
                        Ingredient = new ("1", "Pork bones"),
                        Amount = 5,
                        Measurement = "Kg"
                    }
                },
                Steps = new []
                {
                    "Do stuff"
                }
            }
        };

        return Results.Ok(recipes);
    }
}