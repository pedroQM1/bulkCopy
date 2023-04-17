using ImportManager.Contracts;
using YamlDotNet.Serialization;

namespace ImportManager.Orchestrator
{
    public class OrchestrationYamlfileParse : IOrchestrationfileParse
    {
        public OrchestrationConfiguration ParseSchemaFromFile(string filePath)
        {
            var contentFile = File.ReadAllText(filePath);
            return ParseSchema(contentFile);
        }
        public OrchestrationConfiguration ParseSchema(string content)
        {

            var deserializer = new DeserializerBuilder()
            .Build();

            return deserializer.Deserialize<OrchestrationConfiguration>(content);

        }
    }
}
