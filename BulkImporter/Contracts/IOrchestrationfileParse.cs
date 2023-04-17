


using ImportManager.Orchestrator;

namespace ImportManager.Contracts
{
    internal interface IOrchestrationfileParse
    {
        public OrchestrationConfiguration ParseSchemaFromFile(string filePath);
        public OrchestrationConfiguration ParseSchema(string content);
    }
}
