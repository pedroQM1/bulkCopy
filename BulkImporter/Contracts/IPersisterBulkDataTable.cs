

using System.Data;

namespace BulkImporter.Contracts
{
    internal interface IPersisterBulkDataTable : IDisposable
    {
        Task WriteServerAsync(DataTable dataTable,CancellationToken cancellationToken);
        void WriteServer(DataTable dataTable);
        public int BatchSize { get; }
    }
}
