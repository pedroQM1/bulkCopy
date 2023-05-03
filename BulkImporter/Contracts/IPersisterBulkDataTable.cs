

using System.Data;

namespace BulkImporter.Contracts
{
    internal interface IPersisterBulkDataTable : IDisposable
    {
        Task WriteServerAsync(DataTable dataTable,CancellationToken cancellationToken);
        public int BatchSize { get; }
    }
}
