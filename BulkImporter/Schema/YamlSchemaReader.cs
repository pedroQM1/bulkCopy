

using BulkImporter.Contracts;
using YamlDotNet.Serialization.NamingConventions;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.Schemas;
using ImportManager.Contracts;

namespace ImportManager.Schema
{
    internal class YamlSchemaReader : ISchemaReader
    {
        public ISchema ParseSchemaFromFile(string filePath)
        {
            var contentFile = File.ReadAllText(filePath);
            return ParseSchema(contentFile);
        }
        public ISchema ParseSchema(string content)
        {

            var deserializer = new DeserializerBuilder()
            .Build();

            return deserializer.Deserialize<Schema>(content);

        }


    }
}
