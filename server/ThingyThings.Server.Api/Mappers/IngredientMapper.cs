using ThingyThings.Server.Api.Contract.Requests.Ingredients;
using ThingyThings.Server.Api.Contract.Responses;
using ThingyThings.Server.Api.Models.Recipes;

namespace ThingyThings.Server.Api.Mappers;

public class IngredientMapper :
    IMapper<AddIngredientRequest, Ingredient>,
    IMapper<Ingredient, IngredientResponse>
{
    public Ingredient Map(AddIngredientRequest input)
    {
        return new Ingredient
        {
            Name = input.Body.Name
        };
    }

    public IngredientResponse Map(Ingredient input)
    {
        return new IngredientResponse(input.Id, input.Name);
    }
}