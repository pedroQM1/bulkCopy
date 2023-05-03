using BulkImporter.Contracts;
using BulkImporter.Data;
using BulkImporter.Exceptions;
using BulkImporter.PerseLine;
using ImportManager.Orchestrator;
using ImportManager.Schema;
using Microsoft.Extensions.Logging;

namespace ImportManagerer;

public class ImportManagerComponent : IDisposable
{
    private readonly ISchemaParseLineFactory _schemaParseFactory;
    private readonly IPersisterBulkDataTable _persiterData;
    private readonly ILogger _logger;

    private ImportManagerComponent(
        ISchemaParseLineFactory schemaParseFactory,
        IPersisterBulkDataTable persiterData,
        ILogger logger)
    {
        _schemaParseFactory = schemaParseFactory;
        _persiterData = persiterData;
        _logger = logger;
    }

    public static ImportManagerComponent Create(ILoggerFactory loggerFactory,string connectionString,OrchestrationTaskConfiguration configurarion)
    {


        var schemaParsed = new YamlSchemaReader().ParseSchemaFromFile(configurarion.SchemaFilePath);

        var persisterData = new BulkSqlServerData(
                                                    logger: loggerFactory.CreateLogger<BulkSqlServerData>(),
                                                    connectionString: connectionString,
                                                    destinationTable: configurarion.DestinationTable,
                                                    batcheSize: configurarion.BatchSize);


        var factory = new ClassTypeParseCSVFactory(schema: schemaParsed, defaultValues: configurarion.DefaultValues,loggerFactory);

        return new ImportManagerComponent(
                                    schemaParseFactory: factory,
                                    persiterData: persisterData,
                                    logger: loggerFactory.CreateLogger<ImportManagerComponent>()
                                 );
    }
  
    public async Task ImportFileAsync(string filePathCSV, bool IgnoreImportFileHeader = false,CancellationToken cancellationToken = default)
    {
        _logger.LogInformation($"Read file {filePathCSV}");
        try
        {
            using (StreamReader reader = new StreamReader(filePathCSV))
            {
                if(IgnoreImportFileHeader)reader.ReadLine();
                while (!reader.EndOfStream)
                {
                    using (var dataTable = _schemaParseFactory.Create())
                    {
                        for (int i = 0; i < _persiterData.BatchSize && !reader.EndOfStream; i++) dataTable.Reader(reader.ReadLine()!);
                        await _persiterData.WriteServerAsync(dataTable.DataTable, cancellationToken);
                    }
                }
            }
        }
        catch (PersisterBulkDataTableException ex)
        {
            _logger.LogError("Error persiter data in data base using bulk insert ");
            _logger.LogError(ex.Message, ex);
        }
        catch (SchemaParseLineException ex)
        {
            _logger.LogError("Error parsing csv line for class schema");
            _logger.LogError(ex.Message,ex);
        }
       
       
    }
    public void Dispose()
    {
        _persiterData.Dispose();
    }



}
