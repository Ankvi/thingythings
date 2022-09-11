using ThingyThings.Server.Api.Repositories;

namespace ThingyThings.Server.Api.Services;

public interface IRecipeService
{

}

public class RecipeService : IRecipeService
{
    private readonly IRecipeRepository _repository;

    public RecipeService(IRecipeRepository repository)
    {
        _repository = repository;
    }
}