using GrabrReplica.Common.Configuration;
using Microsoft.Extensions.Configuration;

namespace GrabrReplica.Infrastructure.Configuration
{
    public class ConfigurationHandler : IConfigurationHandler
    {
        public string GetFrontendPath => this.GetString(ConfigurationConstants.CommonConstants.FrontendPathUrl);

        public string GetBackendPath => this.GetString(ConfigurationConstants.CommonConstants.BackendPathUrl);

        private readonly IConfiguration _configuration;

        public ConfigurationHandler(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        private string GetString(string parameterName)
        {
            return _configuration.GetSection(parameterName).Value;
        }

        private int GetInt(string parameterName)
        {
            int.TryParse(_configuration.GetSection(parameterName).Value, out var value);
            return value;
        }
    }
}