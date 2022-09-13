using ThingyThings.Server.Api.Models.Recipes;
using ThingyThings.Server.Api.Repositories;

namespace ThingyThings.Server.Api.Services;

public interface IIngredientService
{
    Task<Ingredient> AddIngredient(Ingredient ingredient, CancellationToken token);
    Task<IEnumerable<Ingredient>> GetIngredients(CancellationToken token);
    Task<Ingredient> GetIngredient(string id, CancellationToken token);
}
public class IngredientService : IIngredientService
{
    private readonly IIngredientRepository _repository;

    public IngredientService(IIngredientRepository repository)
    {
        _repository = repository;
    }
    
    public async Task<Ingredient> AddIngredient(Ingredient ingredient, CancellationToken token)
    {
        return await _repository.AddIngredient(ingredient, token);
    }

    public async Task<IEnumerable<Ingredient>> GetIngredients(CancellationToken token)
    {
        return await _repository.GetIngredients(token);
    }

    public async Task<Ingredient> GetIngredient(string id, CancellationToken token)
    {
        return await _repository.GetIngredient(id, token);
    }
}