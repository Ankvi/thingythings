using System.Linq;
using ThingyThings.Server.Api.Contract.Dtos;
using ThingyThings.Server.Api.Contract.Requests;
using ThingyThings.Server.Api.Contract.Requests.Recipes;
using ThingyThings.Server.Api.Contract.Responses;
using Internal =  ThingyThings.Server.Api.Models.Recipes;

namespace ThingyThings.Server.Api.Mappers;

public class RecipeMapper :
    IMapper<AddRecipeRequest, Internal.Recipe>,
    IMapper<Internal.Recipe, RecipeResponse>
{
    private readonly IRecipeIngredientMapper _ingredientMapper;

    public RecipeMapper(IRecipeIngredientMapper ingredientMapper)
    {
        _ingredientMapper = ingredientMapper;
    }

    public Internal.Recipe Map(AddRecipeRequest input)
    {
        return new()
        {
            Name = input.Body.Name,
            Description = input.Body.Description,
            Ingredients = input.Body.Ingredients.Select(ingredient => _ingredientMapper.Map(ingredient)),
            Steps = input.Body.Steps
        };
    }

    public RecipeResponse Map(Internal.Recipe input)
    {
        return new()
        {
            Id = input.Id,
            Name = input.Name,
            Description = input.Description,
            Steps = input.Steps,
            Ingredients = input.Ingredients.Select(_ingredientMapper.Map)
        };
    }
}