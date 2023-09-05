using SwaggerSample.Core;
using SwaggerSample.Data;

namespace SwaggerSample.Repositories;

public class UserRepository : IUserRepository
{
    private readonly ApplicationContext _dbContext;

    public UserRepository(ApplicationContext dbContext)
    {
        _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
    }

    public User GetUserById(int id)
    {
        return _dbContext.Users.FirstOrDefault(u => u.Id == id);
    }

    public IEnumerable<User> GetAllUsers()
    {
        return _dbContext.Users.ToList();
    }

    public void CreateUser(User user)
    {
        if (user == null)
        {
            throw new ArgumentNullException(nameof(user));
        }

        _dbContext.Users.Add(user);
        _dbContext.SaveChanges();
    }

    public void UpdateUser(User user)
    {
        if (user == null)
        {
            throw new ArgumentNullException(nameof(user));
        }

        _dbContext.Users.Update(user);
        _dbContext.SaveChanges();
    }

    public void DeleteUser(int id)
    {
        var userToDelete = _dbContext.Users.FirstOrDefault(u => u.Id == id);
        if (userToDelete != null)
        {
            _dbContext.Users.Remove(userToDelete);
            _dbContext.SaveChanges();
        }
    }
}
