using System;
using api.Models;
using Microsoft.EntityFrameworkCore;
using todos2.Models;

namespace todos2.Data;

public class AppDBContext : DbContext
{
    public AppDBContext(DbContextOptions<AppDBContext> options)
        : base(options) { }

    public DbSet<Todo> Todos2 { get; set; }
    public DbSet<TodoDetails> TodoDetails { get; set; }
    public DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            var connectionString =
                "Server=localhost\\SQLEXPRESS;Database=Todo2;Trusted_Connection=True;TrustServerCertificate=true";

            optionsBuilder.UseSqlServer(connectionString);
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .Entity<User>()
            .HasData(new User { Id = 1, Name = "Mike" }, new User { Id = 2, Name = "Tim" });

        modelBuilder
            .Entity<Todo>()
            .HasOne(t => t.User)
            .WithMany(u => u.Todos)
            .HasForeignKey(t => t.UserId)
            .IsRequired(false);

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
                    UserId = 1,
                },
                new Todo
                {
                    Id = 2,
                    Title = "Learn ASP.NET Core",
                    IsCompleted = false,
                    CreatedAt = new DateTime(2023, 10, 15),
                    UpdatedAt = new DateTime(2023, 10, 15),
                    UserId = 2,
                },
                new Todo
                {
                    Id = 3,
                    Title = "Build a Web API",
                    IsCompleted = false,
                    CreatedAt = new DateTime(2023, 10, 14),
                    UpdatedAt = new DateTime(2023, 10, 16),
                    UserId = 1,
                }
            );
        modelBuilder
            .Entity<TodoDetails>()
            .HasData(
                new TodoDetails
                {
                    Id = 1,
                    Description = "Need to learn to build a .Net web API",
                    TodoId = 3,
                },
                new TodoDetails
                {
                    Id = 2,
                    Description = "Need to learn more about C sharp",
                    TodoId = 1,
                }
            );
    }
}
