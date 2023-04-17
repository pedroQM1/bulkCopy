

namespace ImportManager.Orchestrator
{
    public class OrchestrationTaskConfiguration
    {
        public string DestinationTable { get; set; }
        public string SchemaFilePath { get; set; }
        public string ImportFilePath { get; set; }
        public bool IgnoreImportFileHeader { get; set; } = false;
        public int BatchSize { get; set; } = 10000;
        public Dictionary<string, object> DefaultValues { get; set; } = new Dictionary<string, object>();
    }
}
