using ImportManager.Contracts;
using ImportManagerer;
using Microsoft.Extensions.Logging;


namespace ImportManager.Orchestrator
{
    public class importOrchestrator
    {

        private readonly IOrchestrationfileParse _bulkConfigurationYamlParse;
        private readonly ILoggerFactory _loggerFactory;

        private importOrchestrator(IOrchestrationfileParse bulkConfigurationYamlParse, ILoggerFactory loggerFactory)
        {
            _bulkConfigurationYamlParse = bulkConfigurationYamlParse;
            _loggerFactory = loggerFactory;
        }

        public static importOrchestrator Create(ILoggerFactory loggerFactory)
        {
            var bulkConfigurationYamlParse = new OrchestrationYamlfileParse();
            return new importOrchestrator(bulkConfigurationYamlParse,loggerFactory);
        }
        public async Task Handler(string configurationPath,CancellationToken cancellationToken = default)
        {
            var configuration = _bulkConfigurationYamlParse.ParseSchemaFromFile(configurationPath);
            foreach (var importTaks in configuration.ImportTaskConfigurations)
            {
                using (var import = ImportManagerComponent.Create(_loggerFactory, configuration.ConnectionString,importTaks))
                {
                    await import.ImportFileAsync(importTaks.ImportFilePath, importTaks.IgnoreImportFileHeader, cancellationToken);
                }
            }

        }
    }
}
