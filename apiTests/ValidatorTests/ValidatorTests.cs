using System;
using todos2.Models;
using todos2.Validator;

namespace apiTests.ValidatorTests;

public class ValidatorTests
{
    [Fact]
    public void TodoValidator_ShouldPass_WhenTitleIsValid()
    {
        // Arrange
        var todo = new Todo { Title = "Valid Todo", IsCompleted = true };
        var validator = new TodoValidator(false);

        // Act
        var result = validator.Validate(todo);

        // Assert
        Assert.True(result.IsValid);
    }

    [Fact]
    public void TodoValidator_ShouldFail_WhenTitleIsEmpty()
    {
        // Arrange
        var todo = new Todo { Title = "", IsCompleted = true };
        var validator = new TodoValidator(false);

        // Act
        var result = validator.Validate(todo);

        // Assert
        Assert.True(!result.IsValid);
        Assert.Equal("Title is required", result.Errors.First().ErrorMessage);
    }

    [Fact]
    public void TodoValidatorIsPostTrue_ShouldPass_WhenTitle_AndIsCompleted_IsValid()
    {
        // Arrange
        var todo = new Todo { Title = "Valid Todo", IsCompleted = false };
        var validator = new TodoValidator(true);

        // Act
        var result = validator.Validate(todo);

        // Assert
        Assert.True(result.IsValid);
    }

    [Fact]
    public void TodoValidatorIsPostTrue_ShouldFail_WhenTitle_OrIsCompleted_IsInValid()
    {
        // Arrange
        var todo = new Todo { Title = "Valid Todo", IsCompleted = true };
        var validator = new TodoValidator(true);

        // Act
        var result = validator.Validate(todo);

        // Assert
        Assert.True(!result.IsValid);
        Assert.Equal("IsCompleted must be false", result.Errors.First().ErrorMessage);
    }

    [Fact]
    public void TodoValidatorIsPostTrue_ShouldFail_WhenTitle_AndIsCompleted_IsInValid()
    {
        // Arrange
        var todo = new Todo { Title = "", IsCompleted = true };
        var validator = new TodoValidator(true);

        // Act
        var result = validator.Validate(todo);

        // Assert
        Assert.True(!result.IsValid);
        Assert.Equal("Title is required", result.Errors[0].ErrorMessage);
        Assert.Equal("IsCompleted must be false", result.Errors[1].ErrorMessage);
    }
}
