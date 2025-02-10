using System;
using todos2.Interfaces;

namespace todos2.Models;

public class CreateTodo : ITodo
{
    public string Title { get; set; } = string.Empty;
    public bool IsCompleted { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;
}
