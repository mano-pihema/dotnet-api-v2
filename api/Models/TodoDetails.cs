using System;

namespace api.Models;

public class TodoDetails
{
    public int Id { get; set; }

    public string? Description { get; set; }

    public int TodoId { get; set; }
}
