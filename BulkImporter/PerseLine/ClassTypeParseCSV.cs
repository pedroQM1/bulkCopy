using BulkImporter.Exceptions;
using ImportManager.Contracts;
using ImportManager.PerseLine;
using Microsoft.Extensions.Logging;
using System.Data;

namespace BulkImporter.PerseLine;

public class ClassTypeParseCSV : Contracts.ISchemaParseLine
{
    public ISchema _schema;

    private DataTable _dataTable;
    public DataTable DataTable => _dataTable;

    public Dictionary<string,object> _defaultValues;

    private ILogger<ClassTypeParseCSV> _logger;

    public ClassTypeParseCSV(ILogger<ClassTypeParseCSV> logger, ISchema schema, Dictionary<string,object> defaultValues)
    {
        _logger = logger;
        _schema = schema;
        _defaultValues = defaultValues;
        _dataTable = new DataTable();
        foreach (var prop in _schema.PropertiesTypes())
        {
            _dataTable.Columns.Add(prop.Key, prop.Value);
        }
    }

    public void Reader(string line)
    {
        try
        {
            var fields = line.Split(',');
            DataRow row = _dataTable.NewRow();
            var index = 0;
            foreach (var prop in _schema.PropertiesTypes())
            {
                if (_defaultValues.Any(x => x.Key == prop.Key)) row[prop.Key] = _defaultValues[prop.Key];
                else
                {
                    var valor = TypeConverter.ChangeType(fields[index], prop.Value);
                    row[prop.Key] = valor;
                }
                index++;
            }
            _dataTable.Rows.Add(row);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, ex.Message);
            _logger.LogError($"Error parsing line : {line}");
            throw new SchemaParseLineException(ex.Message,ex);
        }
    }
  
    public void Dispose()
    {
        _dataTable.Dispose();
    }
}
