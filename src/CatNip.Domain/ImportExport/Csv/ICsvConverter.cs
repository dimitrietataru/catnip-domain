namespace CatNip.Domain.ImportExport.Csv;

public interface ICsvConverter
{
    Task<ICollection<T>> ReadAsync<T>(Stream stream, CancellationToken cancellation = default)
        where T : ICsvMappable;
}
