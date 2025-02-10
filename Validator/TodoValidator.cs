using System;
using FluentValidation;
using todos2.Interfaces;
using todos2.Models;

namespace todos2.Validator;

public class TodoValidator : AbstractValidator<CreateTodo>
{
    public TodoValidator()
    {
        RuleFor(x => x.Title).NotEmpty().WithMessage("Title is required");
        RuleFor(x => x.IsCompleted).Equal(false).WithMessage("IsCompleted must be false");
    }
}
