using MediatR;
using ThingyThings.Server.Api.Contract.Dtos;
using ThingyThings.Server.Api.Contract.Requests;
using ThingyThings.Server.Api.Contract.Responses;
using ThingyThings.Server.Api.Handlers.Attributes;

namespace ThingyThings.Server.Api.Handlers;

[Handler("recipes")]
public class RecipesHandler :
    IRequestHandler<RecipesRequest, IEnumerable<RecipeResponse>>
{
    public async Task<IEnumerable<RecipeResponse>> Handle(RecipesRequest request, CancellationToken cancellationToken)
    {
        var recipes = new List<RecipeResponse>
        {
            new ()
            {
                Id = "1",
                Description = "Pho",
                Ingredients = new []
                {
                    new RecipeIngredient(
                        new Ingredient("1", "Pork bones"),
                        5,
                        "Kg"
                    )
                },
                Steps = new []
                {
                    "Do stuff"
                }
            }
        };

        return recipes;
    }
}