using System.Reflection;
using ApiClient;
using ConfigurationProvider.Contracts;
using ConfigurationProvider.Models;

namespace ConfigurationProvider
{
    public class ConfigurationProvider : IConfigurationProvider
    {
        private readonly IConfigurationManager _configurationManager;
        private readonly IClient _client;

        public ConfigurationProvider(IConfigurationManager configurationManager, IClient client)
        {
            _configurationManager = configurationManager;
            _client = client;
        }
        public FeatureConfiguration? LoadConfig(FilterModel filter)
        {
            var clientResult= _client.Get(filter);
            if (clientResult == null)
            {
                var configFromStorage = _configurationManager.LoadConfigFromFile(Environment.CurrentDirectory + "\\Config.txt");
                if (configFromStorage == null)
                {
                    Console.WriteLine("No storage config or API available");
                    return null;
                }
            }
            var convertedFeatureConfiguration = ConvertToFeatureConfiguration(clientResult.Result);
            SaveConfig(convertedFeatureConfiguration);
            return convertedFeatureConfiguration;

        }

        public void SaveConfig(FeatureConfiguration config)
        {
            _configurationManager.SaveConfigToFile(Environment.CurrentDirectory + "\\Config.txt", config);
        }

        public FeatureConfiguration ConvertToFeatureConfiguration(QueryResult input)
        {
            return new FeatureConfiguration()
            {   App = input.App,
                UserGroup = input.UserGroup,
                IpMask = input.IpMask,
                Device = input.Device,
                CustomFields = input.CustomFields,
                FeatureCode = input.FeatureCode,
                Version = input.Version,
                Enabled = input.Enabled
            }; //TODO: mapping
        }
    }
}
