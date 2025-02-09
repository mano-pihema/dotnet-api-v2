using System;
using todos2.Interfaces;

namespace todos2.Models;

public class UpdateTodo : ITodo
{
    public required string Title { get; set; }
    public bool IsCompleted { get; set; }
    public DateTime UpdatedAt { get; set; } = DateTime.Now;
}
