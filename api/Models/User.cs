using System;
using todos2.Models;

namespace api.Models;

public class User
{
    public int Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public ICollection<Todo>? Todos { get; set; }
}
