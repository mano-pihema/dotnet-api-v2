using System;
using api.Interfaces;
using api.Models;
using Microsoft.EntityFrameworkCore;
using todos2.Data;
using todos2.Exceptions;

namespace api.Repository;

public class UserRepository : IUsersRepository
{
    private readonly AppDBContext _context;

    public UserRepository(AppDBContext context)
    {
        _context = context;
    }

    public async Task<User> GetUserAsync(int id)
    {
        var user = await _context.Users.Include(u => u.Todos).FirstOrDefaultAsync(u => u.Id == id);

        if (user == null)
        {
            throw new IdNotFoundException($"Todo with id {id} not found");
        }

        return user;
    }

    public async Task<IEnumerable<User>> GetUsersAsync()
    {
        return await _context
            .Users.Include(u => u.Todos)
            .ThenInclude(t => t.TodoDetails)
            .ToListAsync();
    }
}
