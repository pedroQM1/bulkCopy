using BulkImporter.Contracts;
using BulkImporter.Exceptions;
using Microsoft.Extensions.Logging;
using System.Data;
using System.Data.SqlClient;
using System.Threading;

namespace BulkImporter.Data;

public class BulkSqlServerData : IPersisterBulkDataTable
{
    SqlBulkCopy _bulk;
    SqlConnection _dbconn;
    public int BatchSize => _bulk.BatchSize;

    private ILogger<BulkSqlServerData> _logger;

    public BulkSqlServerData(ILogger<BulkSqlServerData> logger,string connectionString,string destinationTable, int notifyinsertBulkAfter = 5000, int batcheSize = 10000)
    {

        _logger = logger;
        _dbconn = new SqlConnection(connectionString);
        _dbconn.Open();

        _bulk = new SqlBulkCopy(_dbconn);
        _bulk.DestinationTableName = destinationTable;
        _bulk.BatchSize = batcheSize;
        _bulk.BulkCopyTimeout = 120;
        _bulk.EnableStreaming = true;
        _bulk.NotifyAfter = notifyinsertBulkAfter;
        _bulk.SqlRowsCopied += (sender, eventArgs) =>
        {
            _logger.LogInformation($"Insert total line in database : {eventArgs.RowsCopied} - timeout:{_bulk.BulkCopyTimeout}");
        };

    }
    public async Task WriteServerAsync(DataTable dataTable,CancellationToken cancellationToken)
    {
        try
        {
            await _bulk.WriteToServerAsync(dataTable, cancellationToken);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message,ex);
            throw new PersisterBulkDataTableException(ex.Message,ex);
        }
    }
    public void WriteServer(DataTable dataTable)
    {
        try
        {
            _bulk.WriteToServer(dataTable);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message, ex);
            throw new PersisterBulkDataTableException(ex.Message, ex);
        }
    }
   
    public void Dispose()
    {
        _bulk.Close();
        _dbconn.Close();
        _dbconn.Dispose();
    }

    
}
