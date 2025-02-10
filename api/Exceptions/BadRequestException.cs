using System;

namespace todos2.Exceptions;

public class BadRequestException : ApplicationException
{
    public BadRequestException(string message)
        : base(message) { }
}
