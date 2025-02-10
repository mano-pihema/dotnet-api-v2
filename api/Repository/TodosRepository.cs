using System;
using Microsoft.EntityFrameworkCore;
using todos2.Data;
using todos2.Exceptions;
using todos2.Interfaces;
using todos2.Models;

namespace todos2.Repository;

public class TodosRepository : ITodosRepository
{
    private readonly AppDBContext _context;

    public TodosRepository(AppDBContext context)
    {
        _context = context;
    }

    public async Task<Todo> CreateTodoAsync(CreateTodo todo)
    {
        var newTodo = new Todo
        {
            Title = todo.Title,
            IsCompleted = todo.IsCompleted,
            CreatedAt = DateTime.Now,
            UpdatedAt = DateTime.Now,
        };

        await _context.Todos2.AddAsync(newTodo);
        await _context.SaveChangesAsync();
        return newTodo;
    }

    public async Task<Todo?> DeleteTodoAsync(int id)
    {
        var todo = await _context.Todos2.FindAsync(id);
        if (todo == null)
        {
            throw new IdNotFoundException($"Todo with id {id} not found");
        }
        _context.Remove(todo);
        await _context.SaveChangesAsync();
        return todo;
    }

    public async Task<Todo?> GetTodoByIdAsync(int id)
    {
        var todo = await _context.Todos2.FindAsync(id);
        if (todo == null)
        {
            throw new IdNotFoundException($"Todo with id {id} not found");
        }
        return todo;
    }

    public async Task<IEnumerable<Todo>> GetTodosAsync()
    {
        return await _context.Todos2.ToListAsync();
    }

    public async Task<Todo?> UpdateTodoAsync(int id, UpdateTodo updateTodo)
    {
        var todo = await GetTodoByIdAsync(id);

        if (todo == null)
        {
            throw new IdNotFoundException($"Todo with id {id} not found");
        }

        todo.IsCompleted = updateTodo.IsCompleted;
        todo.Title = updateTodo.Title;
        todo.UpdatedAt = updateTodo.UpdatedAt;

        await _context.SaveChangesAsync();
        return todo;
    }
}
