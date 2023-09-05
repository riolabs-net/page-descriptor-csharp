﻿using SwaggerSample.Data;

namespace SwaggerSample.Core;

public interface IUserService
{
    User GetUserById(int id);
    IEnumerable<User> GetAllUsers();
    void CreateUser(User user);
    void UpdateUser(User user);
    void DeleteUser(int id);
}