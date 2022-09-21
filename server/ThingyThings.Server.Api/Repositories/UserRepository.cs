using ThingyThings.Server.Api.Models.Users;

namespace ThingyThings.Server.Api.Repositories;

public interface IUserRepository
{
    Task<User?> LoginUser(string email, string password, CancellationToken token);
    Task<User> RegisterUser(User user, CancellationToken token);
}

public class UserRepository : IUserRepository
{
    public Task<User?> LoginUser(string email, string password, CancellationToken token)
    {
        throw new NotImplementedException();
    }

    public Task<User> RegisterUser(User user, CancellationToken token)
    {
        throw new NotImplementedException();
    }
}
