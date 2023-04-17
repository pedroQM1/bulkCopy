using BulkImporter.Contracts;
using ImportManager.Contracts;
using Microsoft.Extensions.Logging;

namespace BulkImporter.PerseLine
{
    internal class ClassTypeParseCSVFactory : ISchemaParseLineFactory
    {

        private readonly ISchema _schema;

        private readonly Dictionary<string, Object> _defaultValues;

        private readonly ILoggerFactory _loggerFactory;

        public ClassTypeParseCSVFactory(ISchema schema, Dictionary<string, object> defaultValues, ILoggerFactory loggerFactory)
        {
            _schema = schema;
            _defaultValues = defaultValues;
            _loggerFactory = loggerFactory;
        }

        public ISchemaParseLine Create()
        {
            var logger = _loggerFactory.CreateLogger<ClassTypeParseCSV>();
            return new ClassTypeParseCSV(logger,_schema, _defaultValues);
        }
    }
}
