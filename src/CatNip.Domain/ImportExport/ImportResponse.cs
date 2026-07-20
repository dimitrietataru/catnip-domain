namespace CatNip.Domain.ImportExport;

public class ImportResponse
{
    public required bool IsSuccessful { get; init; }

    public int TotalRows { get; init; }
    public int CreatedRecords { get; init; }
    public int UpdatedRecords { get; init; }

    public required virtual IEnumerable<ImportError> Errors { get; init; } = [];

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

    public static ImportResponse Failure(params IEnumerable<ImportError> errors)
    {
        return new ImportResponse
        {
            IsSuccessful = false,
            Errors = errors
        };
    }
}

public abstract class ImportError
{
    protected ImportError()
    {
        RowNumber = -1;
    }

    [SetsRequiredMembers]
    protected ImportError(string errorMessage)
        : base()
    {
        ErrorMessage = errorMessage;
    }

    [SetsRequiredMembers]
    protected ImportError(int rowNumber, string errorMessage)
    {
        RowNumber = rowNumber;
        ErrorMessage = errorMessage;
    }

    public virtual int RowNumber { get; init; }
    public virtual required string ErrorMessage { get; init; }
}

public sealed class ImportParseError : ImportError
{
    public ImportParseError()
        : base()
    {
    }

    [SetsRequiredMembers]
    public ImportParseError(string errorMessage)
        : base(-1, errorMessage)
    {
    }
}

public sealed class ImportValidationError : ImportError
{
    public ImportValidationError()
        : base()
    {
    }

    [SetsRequiredMembers]
    public ImportValidationError(string errorMessage)
        : base(errorMessage)
    {
    }

    [SetsRequiredMembers]
    public ImportValidationError(int rowNumber, string errorMessage)
        : base(rowNumber, errorMessage)
    {
    }
}

public sealed class ImportDataIntegrityError : ImportError
{
    public ImportDataIntegrityError()
        : base()
    {
    }

    [SetsRequiredMembers]
    public ImportDataIntegrityError(string errorMessage)
        : base(errorMessage)
    {
    }

    [SetsRequiredMembers]
    public ImportDataIntegrityError(int rowNumber, string errorMessage)
        : base(rowNumber, errorMessage)
    {
    }
}
