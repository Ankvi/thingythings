using ThingyThings.Server.Api.Contract.Responses;
using ThingyThings.Server.Api.Models.Recipes;
using ThingyThings.Server.Api.Repositories;

namespace ThingyThings.Server.Api.Services;

public interface IRecipeService
{
    Task<Recipe> AddRecipe(Recipe recipe, CancellationToken token);
    Task<IEnumerable<Recipe>> GetRecipes(CancellationToken token);
    Task AddIngredientToRecipe(string id, RecipeIngredient ingredient, CancellationToken token);
}

public class RecipeService : IRecipeService
{
    private readonly IRecipeRepository _repository;

    public RecipeService(IRecipeRepository repository)
    {
        _repository = repository;
    }

    public async Task<Recipe> AddRecipe(Recipe recipe, CancellationToken token)
    {
        return await _repository.AddRecipe(recipe, token);
    }

    public async Task<IEnumerable<Recipe>> GetRecipes(CancellationToken token)
    {
        return await _repository.GetRecipes(token);
    }

    public async Task AddIngredientToRecipe(string id, RecipeIngredient ingredient, CancellationToken token)
    {
        await _repository.AddIngredientToRecipe(id, ingredient, token);
    }
}