namespace ImportManager.Orchestrator
{
    public class OrchestrationConfiguration
    {
        public string ConnectionString { get; set; }
        public List<OrchestrationTaskConfiguration> ImportTaskConfigurations { get; set; }

    }
}
