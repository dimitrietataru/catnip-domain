using CatNip.Domain.Exceptions.Abstractions;

namespace CatNip.Domain.Exceptions;

public class DataNotFoundException : NotFoundException
{
    public DataNotFoundException()
        : base()
    {
    }

    public DataNotFoundException(string message)
        : base(message)
    {
    }

    public DataNotFoundException(string message, Exception innerException)
        : base(message, innerException)
    {
    }
}
