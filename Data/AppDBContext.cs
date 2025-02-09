using System;
using Microsoft.EntityFrameworkCore;
using todos2.Models;

namespace todos2.Data;

public class AppDBContext : DbContext
{
    public AppDBContext(DbContextOptions<AppDBContext> options)
        : base(options) { }

    public DbSet<Todo> Todos2 { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var connectionString =
            "Server=localhost\\SQLEXPRESS;Database=Todo2;Trusted_Connection=True;TrustServerCertificate=true";

        optionsBuilder.UseSqlServer(connectionString);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .Entity<Todo>()
            .HasData(
                new Todo
                {
                    Id = 1,
                    Title = "Learn C#",
                    IsCompleted = false,
                    CreatedAt = new DateTime(2023, 10, 15),
                    UpdatedAt = new DateTime(2023, 10, 15),
                },
                new Todo
                {
                    Id = 2,
                    Title = "Learn ASP.NET Core",
                    IsCompleted = false,
                    CreatedAt = new DateTime(2023, 10, 15),
                    UpdatedAt = new DateTime(2023, 10, 15),
                },
                new Todo
                {
                    Id = 3,
                    Title = "Build a Web API",
                    IsCompleted = false,
                    CreatedAt = new DateTime(2023, 10, 14),
                    UpdatedAt = new DateTime(2023, 10, 16),
                }
            );
    }
}
