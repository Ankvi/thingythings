using ThingyThings.Server.Api.Contract.Requests.Users;
using ThingyThings.Server.Api.Contract.Responses.Users;
using ThingyThings.Server.Api.Models.Users;

namespace ThingyThings.Server.Api.Mappers;

public class UserMapper :
    IMapper<RegisterUserRequest, NewUser>,
    IMapper<User, UserRegisteredResponse>
{
    public NewUser Map(RegisterUserRequest input)
    {
        return new NewUser
        {
            Email = input.Details.Email,
            Password = input.Details.Password
        };
    }

    public UserRegisteredResponse Map(User input)
    {
        throw new NotImplementedException();
    }
}
