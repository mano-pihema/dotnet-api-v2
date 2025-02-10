using System;
using api.Interfaces;
using api.Models;

namespace api.Repository;

public class UserRepository : IUsersRepository
{
    public Task<User> GetUserAsync()
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<User>> GetUsersAsync()
    {
        throw new NotImplementedException();
    }
}
