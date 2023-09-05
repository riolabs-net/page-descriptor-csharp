using SwaggerSample.Data;

namespace SwaggerSample.Core;

public interface IUserRepository
{
    void CreateUser(User user);
    void DeleteUser(int id);
    IEnumerable<User> GetAllUsers();
    User GetUserById(int id);
    void UpdateUser(User user);
}
