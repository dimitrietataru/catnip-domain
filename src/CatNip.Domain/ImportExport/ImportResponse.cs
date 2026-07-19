namespace CatNip.Domain.ImportExport;

public class ImportResponse
{
    public required bool IsSuccessful { get; init; }

    public int TotalRows { get; init; }
    public int CreatedRecords { get; init; }
    public int UpdatedRecords { get; init; }

    public required virtual IEnumerable<ImportValidationError> Errors { get; init; } = [];

    public static ImportResponse Success(int totalRows, int createdRecords, int updatedRecords)
    {
        return new ImportResponse
        {
            IsSuccessful = true,
            TotalRows = totalRows,
            CreatedRecords = createdRecords,
            UpdatedRecords = updatedRecords,
            Errors = []
        };
    }

    public static ImportResponse Failure(ImportValidationError error)
    {
        return new ImportResponse
        {
            IsSuccessful = false,
            Errors = [error]
        };
    }

    public static ImportResponse Failure(IEnumerable<ImportValidationError> errors)
    {
        return new ImportResponse
        {
            IsSuccessful = false,
            Errors = errors
        };
    }
}

public sealed class ImportValidationError
{
    public int RowNumber { get; set; } = -1;
    public string ErrorMessage { get; set; } = default!;
}
