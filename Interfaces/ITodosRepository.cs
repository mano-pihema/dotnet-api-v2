using System;
using todos2.Models;

namespace todos2.Interfaces;

public interface ITodosRepository
{
    Task<IEnumerable<Todo>> GetTodosAsync();
    Task<Todo?> GetTodoByIdAsync(int id);
    Task<Todo> CreateTodoAsync(CreateTodo todo);
    Task<Todo?> UpdateTodoAsync(int id, UpdateTodo todo);
    Task<Todo?> DeleteTodoAsync(int id);
}
