namespace CatNip.Domain.ImportExport.Excel;

public interface IExcelConverter
{
    Task<ICollection<TExcel>> ReadAsync<TExcel>(Stream stream, CancellationToken cancellation = default)
        where TExcel : IExcelMappable;
}
