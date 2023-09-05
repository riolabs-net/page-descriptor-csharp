using SwaggerSample.Core;
using SwaggerSample.Data;

namespace SwaggerSample.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public User GetUserById(int id)
    {
        return _userRepository.GetUserById(id);
    }

    public IEnumerable<User> GetAllUsers()
    {
        return _userRepository.GetAllUsers();
    }

    public void CreateUser(User user)
    {
        _userRepository.CreateUser(user);
    }

    public void UpdateUser(User user)
    {
        _userRepository.UpdateUser(user);
    }

    public void DeleteUser(int id)
    {
        _userRepository.DeleteUser(id);
    }
}