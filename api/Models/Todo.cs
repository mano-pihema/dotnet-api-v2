using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using api.Models;
using todos2.Interfaces;

namespace todos2.Models;

public class Todo : ITodo
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public bool IsCompleted { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public TodoDetails? TodoDetails { get; set; }
    public int? UserId { get; set; }

    [JsonIgnore]
    public User? User { get; set; }
}
