using ThingyThings.Server.Api.Models.Categories;
using ThingyThings.Server.Api.Repositories;
using ThingyThings.Server.Api.Types;

namespace ThingyThings.Server.Api.Services;

public interface ICategoryService
{
    Task<IEnumerable<Category>> GetCategories(CategoryType? type, CancellationToken token);
    Task<Category> AddCategory(Category category, CancellationToken token);
}

public class CategoryService : ICategoryService
{
    private readonly ICategoryRepository _repository;

    public CategoryService(ICategoryRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<Category>> GetCategories(CategoryType? type, CancellationToken token)
    {
        if (type.HasValue)
        {
            return await _repository.GetCategories(type.Value, token);
        }

        return await _repository.GetCategories(token);
    }

    public async Task<Category> AddCategory(Category category, CancellationToken token)
    {
        return await _repository.AddCategory(category, token);
    }
}
