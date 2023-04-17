using BulkImporter.Contracts;
using ImportManager.Contracts;


namespace ImportManager.Schema
{
    public class Schema : ISchema
    {
        public Dictionary<string, string> Properties { get; set; }

        public Dictionary<string, Type> PropertiesTypes()
        {
            var tipos = new Dictionary<string, Type>();
            foreach (var keyValue in Properties)
            {
                var type = Type.GetType(keyValue.Value);
                if (type != null) tipos.Add(keyValue.Key, type);
            }
            return tipos;
        }
    }
}
