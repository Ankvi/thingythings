using Npgsql;
using ThingyThings.Server.Api.Database;
using ThingyThings.Server.Api.Models.Categories;
using ThingyThings.Server.Api.Types;

namespace ThingyThings.Server.Api.Repositories;

public interface ICategoryRepository
{
    Task<IEnumerable<Category>> GetCategories(CategoryType type, CancellationToken token);
    Task<IEnumerable<Category>> GetCategories(CancellationToken token);
    Task<Category> AddCategory(Category category, CancellationToken token);
}

public class CategoryRepository : ICategoryRepository
{
    private readonly IPostgresDatabase _database;

    public CategoryRepository(IPostgresDatabase database)
    {
        _database = database;
    }

    public async Task<IEnumerable<Category>> GetCategories(CategoryType type, CancellationToken token)
    {
        return await _database.Get<Category>(@"
            SELECT *
            FROM category.categories
            WHERE type = @type
        ", new []
        {
            new NpgsqlParameter("type", type.ToString())
        }, token);
    }

    public async Task<IEnumerable<Category>> GetCategories(CancellationToken token)
    {
        return await _database.Get<Category>(@"
            SELECT * FROM category.categories
        ", token);
    }

    public async Task<Category> AddCategory(Category category, CancellationToken token)
    {
        return await _database.GetSingle<Category>(@"
            INSERT INTO category.Categories(type, name)
            VALUES($1, $2)
        ", new List<NpgsqlParameter>
        {
            new NpgsqlParameter<CategoryType>{ TypedValue = category.Type },
            new NpgsqlParameter<string>{ TypedValue = category.Name }
        },token);
    }
}
