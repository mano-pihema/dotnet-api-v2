using System;
using Microsoft.EntityFrameworkCore;
using todos2.Data;
using todos2.Exceptions;
using todos2.Models;
using todos2.Repository;

namespace apiTests.Repository;

public class TodoRepositoryTests
{
    private AppDBContext GetInMemoryDbContext()
    {
        var options = new DbContextOptionsBuilder<AppDBContext>()
            .UseInMemoryDatabase(databaseName: "TestDatabase")
            .Options;
        var context = new AppDBContext(options);

        context.Database.EnsureDeleted();

        context.Todos2.AddRange(
            new List<Todo>
            {
                new Todo { Title = "Seeded Todo 1", IsCompleted = true },
                new Todo { Title = "Seeded Todo 2", IsCompleted = false },
            }
        );
        context.SaveChanges();

        return context;
    }

    [Fact]
    public async Task GetAllTodoAsync_RetrivesAllTodosFromDatabase()
    {
        // Arrange
        var context = GetInMemoryDbContext();
        var repository = new TodosRepository(context);

        // Act
        var todos = await repository.GetTodosAsync();

        // Assert
        Assert.NotNull(todos);
        Assert.Equal(2, todos.Count());
    }

    [Fact]
    public async Task CreateTodoAsync_SavesTodoToDatabase()
    {
        // Arrange
        var context = GetInMemoryDbContext();
        var repository = new TodosRepository(context);
        var todo = new CreateTodo { Title = "Test Todo", IsCompleted = false };

        // Act
        await repository.CreateTodoAsync(todo);
        var savedTodo = await context.Todos2.FindAsync(3);

        // Assert
        Assert.NotNull(savedTodo);
        Assert.Equal("Test Todo", savedTodo.Title);
    }

    [Fact]
    public async Task UpdateTodoAsync_updatesTodoInDatabase()
    {
        // Arrange
        var context = GetInMemoryDbContext();
        var repository = new TodosRepository(context);
        var todo = new UpdateTodo { Title = "Test Update Todo", IsCompleted = false };

        // Act
        await repository.UpdateTodoAsync(1, todo);
        var updatedTodo = await context.Todos2.FindAsync(1);

        // Assert
        Assert.NotNull(updatedTodo);
        Assert.Equal("Test Update Todo", updatedTodo.Title);
    }

    [Fact]
    public async Task DeleteTodoAsync_removesTodoInDatabase()
    {
        // Arrange
        var context = GetInMemoryDbContext();
        var repository = new TodosRepository(context);

        // Act
        await repository.DeleteTodoAsync(1);
        var deletedTodo = await context.Todos2.FindAsync(1);

        // Assert
        Assert.Null(deletedTodo);
    }

    [Fact]
    public async Task FindTodoAsync_retrievesOneTodoInDatabase()
    {
        // Arrange
        var context = GetInMemoryDbContext();
        var repository = new TodosRepository(context);

        // Act
        var todo = await repository.GetTodoByIdAsync(1);

        // Assert
        Assert.NotNull(todo);
        Assert.Equal("Seeded Todo 1", todo.Title);
    }

    [Fact]
    public async Task FindTodoAsync_ThrowsIdNotFoundException()
    {
        // Arrange
        var context = GetInMemoryDbContext();
        var repository = new TodosRepository(context);
        //Assert
        await Assert.ThrowsAsync<IdNotFoundException>(() => repository.GetTodoByIdAsync(99));
    }

    [Fact]
    public async Task DeleteTodoAsync_ThrowsIdNotFoundException()
    {
        // Arrange
        var context = GetInMemoryDbContext();
        var repository = new TodosRepository(context);
        //Assert
        await Assert.ThrowsAsync<IdNotFoundException>(() => repository.DeleteTodoAsync(99));
    }

    [Fact]
    public async Task UpdateTodoAsync_ThrowsIdNotFoundException()
    {
        // Arrange
        var context = GetInMemoryDbContext();
        var repository = new TodosRepository(context);

        var todo = new UpdateTodo { Title = "Test Update Todo", IsCompleted = false };
        //Assert
        await Assert.ThrowsAsync<IdNotFoundException>(() => repository.UpdateTodoAsync(99, todo));
    }
}
