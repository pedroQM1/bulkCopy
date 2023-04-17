

namespace BulkImportService.Serializer
{
    internal interface IFileSerializer {

        public string Serialize<Type>(Type content);
        public Type Deserialize<Type>(string content);
    }
}
