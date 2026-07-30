namespace CatNip.Domain.Exceptions.Abstractions;

public abstract class MappingNotFoundException : NotFoundException
{
    protected MappingNotFoundException()
        : base()
    {
    }

    protected MappingNotFoundException(string message)
        : base(message)
    {
    }

    protected MappingNotFoundException(string message, Exception innerException)
        : base(message, innerException)
    {
    }

    protected MappingNotFoundException(Type type)
        : base($"No mapping registered for {type.Name}.")
    {
    }

    protected MappingNotFoundException(Type type, Exception innerException)
        : base($"No mapping registered for {type.Name}.", innerException)
    {
    }
}
