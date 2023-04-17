
using YamlDotNet.Serialization.NamingConventions;
using YamlDotNet.Serialization;

namespace BulkImportService.Serializer
{
    public class FileYamlSerializer : IFileSerializer
    {

        ISerializer _serializer;
        IDeserializer _deserializer;

        public FileYamlSerializer() {

            _serializer = new SerializerBuilder()
            .WithNamingConvention(CamelCaseNamingConvention.Instance)
            .Build();

            _deserializer = new DeserializerBuilder()
            .WithNamingConvention(UnderscoredNamingConvention.Instance) 
            .Build();
        }
        public Type Deserialize<Type>(string content)
        {
            return _deserializer.Deserialize<Type>(content);
        }

        public string Serialize<Type>(Type content)
        {
            return _serializer.Serialize(content);
        }
    }
}
