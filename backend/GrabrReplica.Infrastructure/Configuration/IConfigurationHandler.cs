namespace GrabrReplica.Infrastructure.Configuration
{
    public interface IConfigurationHandler
    {
        string GetFrontendPath { get; }
        
        string GetBackendPath { get; }
    }
}