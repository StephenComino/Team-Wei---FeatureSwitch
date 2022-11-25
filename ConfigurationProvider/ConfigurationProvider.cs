using System.Reflection;
using ConfigurationProvider.Contracts;
using ConfigurationProvider.Models;

namespace ConfigurationProvider
{
    public class ConfigurationProvider : IConfigurationProvider
    {
        private readonly IConfigurationManager _configurationManager;
        public ConfigurationProvider(IConfigurationManager configurationManager)
        {
            _configurationManager = configurationManager;
        }
        public FeatureConfiguration LoadConfig()
        {
            return _configurationManager.LoadConfigFromFile(Assembly.GetExecutingAssembly().Location);
        }

        public void SaveConfig(FeatureConfiguration config)
        {
            _configurationManager.SaveConfigToFile(Assembly.GetExecutingAssembly().Location, config);
        }
    }
}
