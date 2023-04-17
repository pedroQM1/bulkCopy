

using ImportManager.Contracts;

namespace BulkImporter.Contracts
{
    internal interface ISchemaReader
    {
        public ISchema ParseSchemaFromFile(string filePath);

        public ISchema ParseSchema(string content);
    }
}
