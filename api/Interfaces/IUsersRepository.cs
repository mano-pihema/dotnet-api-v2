using System;
using api.Models;

namespace api.Interfaces;

public interface IUsersRepository
{
    Task<IEnumerable<User>> GetUsersAsync();

    Task<User> GetUserAsync();
}
