namespace CatNip.Domain.ImportExport;

public class ImportRequest : IDisposable
{
    private bool isDisposed;

    public ImportRequest()
    {
    }

    [SetsRequiredMembers]
    public ImportRequest(Stream stream, string fileName)
    {
        Stream = stream;
        FileName = fileName;
    }

    public required virtual Stream Stream { get; init; }
    public required virtual string FileName { get; init; }

    protected virtual void Dispose(bool disposing)
    {
        if (isDisposed)
        {
            return;
        }

        if (disposing)
        {
            Stream?.Dispose();
        }

        isDisposed = true;
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }
}
