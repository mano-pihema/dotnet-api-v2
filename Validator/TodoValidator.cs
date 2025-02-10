using System;
using FluentValidation;
using todos2.Interfaces;
using todos2.Models;

namespace todos2.Validator;

public class TodoValidator : AbstractValidator<ITodo>
{
    public TodoValidator(bool isPost)
    {
        RuleFor(x => x.Title).NotEmpty().WithMessage("Title is required");
        if (isPost)
        {
            RuleFor(x => x.IsCompleted).Equal(false).WithMessage("IsCompleted must be false");
        }
    }
}
