using CatNip.Domain.Exceptions.Abstractions;

namespace CatNip.Domain.Exceptions;

public class ExcelMappingNotFoundException : MappingNotFoundException
{
    public ExcelMappingNotFoundException()
        : base()
    {
    }

    public ExcelMappingNotFoundException(string message)
        : base(message)
    {
    }

    public ExcelMappingNotFoundException(string message, Exception innerException)
        : base(message, innerException)
    {
    }

    public ExcelMappingNotFoundException(Type type)
        : base($"No excel mapping registered for {type.Name}.")
    {
    }

    public ExcelMappingNotFoundException(Type type, Exception innerException)
        : base($"No excel mapping registered for {type.Name}.", innerException)
    {
    }
}
