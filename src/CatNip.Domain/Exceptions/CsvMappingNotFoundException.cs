using CatNip.Domain.Exceptions.Abstractions;

namespace CatNip.Domain.Exceptions;

public class CsvMappingNotFoundException : MappingNotFoundException
{
    public CsvMappingNotFoundException()
        : base()
    {
    }

    public CsvMappingNotFoundException(string message)
        : base(message)
    {
    }

    public CsvMappingNotFoundException(string message, Exception innerException)
        : base(message, innerException)
    {
    }

    public CsvMappingNotFoundException(Type type)
        : base($"No csv mapping registered for {type.Name}.")
    {
    }

    public CsvMappingNotFoundException(Type type, Exception innerException)
        : base($"No csv mapping registered for {type.Name}.", innerException)
    {
    }
}
