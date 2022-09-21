using ThingyThings.Server.Api.Models.Users;
using ThingyThings.Server.Api.Repositories;

namespace ThingyThings.Server.Api.Services;

public interface IUserService
{
    Task<User?> LoginUser(string email, string password, CancellationToken token);
    Task<User> RegisterUser(User user, CancellationToken token);
}

public class UserService : IUserService
{
    private readonly IUserRepository _repository;

    public UserService(IUserRepository repository)
    {
        _repository = repository;
    }

    public async Task<User?> LoginUser(string email, string password, CancellationToken token)
    {
        return await _repository.LoginUser(email, password, token);
    }

    public async Task<User> RegisterUser(User user, CancellationToken token)
    {
        return await _repository.RegisterUser(user, token);
    }
}
