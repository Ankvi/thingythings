using System.Linq;
using ThingyThings.Server.Api.Contract.Dtos;
using ThingyThings.Server.Api.Contract.Requests;
using Internal =  ThingyThings.Server.Api.Models.Recipes;

namespace ThingyThings.Server.Api.Mappers;

public class RecipeMapper : IMapper<AddRecipeRequest, Internal.Recipe>
{
    private readonly IMapper<RecipeIngredient, Internal.RecipeIngredient> _ingredientMapper;

    public RecipeMapper(IMapper<RecipeIngredient, Internal.RecipeIngredient> ingredientMapper)
    {
        _ingredientMapper = ingredientMapper;
    }

    public Internal.Recipe Map(AddRecipeRequest input)
    {
        return new()
        {
            Description = input.Description,
            Ingredients = input.Ingredients.Select(ingredient => _ingredientMapper.Map(ingredient)),
            Steps = input.Steps
        };
    }
}