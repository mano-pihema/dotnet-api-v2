using System;

namespace todos2.Interfaces;

public interface ITodo
{
    string Title { get; set; }
    bool IsCompleted { get; set; }
    DateTime UpdatedAt { get; set; }
}
