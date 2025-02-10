using System;

namespace todos2.Exceptions;

public class IdNotFoundException : ApplicationException
{
    public IdNotFoundException(string message)
        : base(message) { }
}
