namespace CatNip.Domain.ImportExport.Csv;

public interface ICsvConverter
{
    Task<ICollection<TCsv>> ReadAsync<TCsv>(Stream stream, CancellationToken cancellation = default)
        where TCsv : ICsvMappable;
}
